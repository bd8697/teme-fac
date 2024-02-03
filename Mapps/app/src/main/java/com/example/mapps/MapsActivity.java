package com.example.mapps;

import androidx.fragment.app.FragmentActivity;

import android.app.ActionBar;
import android.content.Intent;
import android.graphics.Color;
import android.location.Location;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Parcelable;
import android.util.Pair;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.Polyline;
import com.google.android.gms.maps.model.PolylineOptions;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;


public class MapsActivity extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;
    private CountDownTimer mCountDownTimer;
    private TextView timerTextView;
    private GameState gameState;
    LatLng choiceCoords; //Latitude, in degrees. This value is in the range [-90, 90]. Longitude, in degrees. This value is in the range [-180, 180).
    private boolean guessed = false;
    Marker lastMarker;
    Polyline lastLine;
    TextView scoreView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
    }

    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;
        gameState = new GameState("Player", 0, 0, 0, true, true, new myPair<Double, Double>(0.0, 0.0));
        choiceCoords = new LatLng(0,0);
        guessed = false;
        scoreView = (TextView) findViewById(R.id.scoreTextView);

        LatLng rndLatLng = new LatLng((int) (Math.random() * (90 - (-90) + 1) + (-90)), (int) (Math.random() * (180 - (-180) + 1) + (-180)));
        mMap.moveCamera(CameraUpdateFactory.newLatLng(rndLatLng));
        choiceCoords = rndLatLng;

        mMap.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
            @Override
            public void onMapClick(LatLng point) {
                if(gameState.getRound() > 0 && !guessed) {
                    MarkerOptions marker = new MarkerOptions().position(new LatLng(point.latitude, point.longitude)).title("I was here");
                    if(lastMarker != null)
                        lastMarker.remove();
                    lastMarker = mMap.addMarker(marker);
                    choiceCoords = new LatLng(point.latitude, point.longitude);
                    System.out.println(point.latitude+"---"+ point.longitude);
                }
            }
        });

        //
        Intent intent = getIntent();
        if(intent.getSerializableExtra("gameState") != null) {
            gameState = new GameState((GameState) intent.getSerializableExtra("gameState"));
        }
        //

        if (gameState.getRound() > 0) {
            Button myButton=(Button)findViewById(R.id.guessBtn);
            myButton.setVisibility(View.VISIBLE);

            myButton=(Button)findViewById(R.id.startBtn);
            myButton.setVisibility(View.INVISIBLE);

            TextView txt=(TextView) findViewById(R.id.timerTextView);
            txt.setVisibility(View.VISIBLE);

            txt=(TextView) findViewById(R.id.roundTextView);
            txt.setVisibility(View.VISIBLE);

            if(gameState.HasTip()) {
                myButton=(Button)findViewById(R.id.hintBtn);
                myButton.setVisibility(View.VISIBLE);
            }

            if(gameState.HasPlusTime()) {
                myButton=(Button)findViewById(R.id.plusTimeBtn);
                myButton.setVisibility(View.VISIBLE);
            }

            Toast.makeText(this,"Where were you?", Toast.LENGTH_LONG).show();
        } else {
            intent = new Intent(MapsActivity.this, BackgroundSoundService.class);
            startService(intent);
        }

        if(gameState.getTimeLeft() > 0) {
            timerTextView = (TextView) findViewById(R.id.timerTextView);
            TextView roundView = (TextView) findViewById(R.id.roundTextView);
            if(gameState.getRound() > 0) {
                scoreView.setText("" + gameState.getScore()+ " ");
            }
            roundView.setText("ROUND " + gameState.getRound()+ " ");
            createCountDownTimer();
        }
    }

    private void createCountDownTimer() {
        mCountDownTimer = new CountDownTimer(gameState.getTimeLeft(), 1000) {
            public void onTick(long millisUntilFinished) {
                if(millisUntilFinished / 1000 < 1) {
                    choiceCoords = new LatLng((int) (Math.random() * (90 - (-90) + 1) + (-90)), (int) (Math.random() * (180 - (-180) + 1) + (-180)));
                    Guessed();
                }
                if(!guessed){
                    timerTextView.setText(millisUntilFinished / 1000 / 60 + ":" + (60 - ((Utility.timeLeftStart - millisUntilFinished) / 1000 % 60)) + " ");
                }
            }
            public void onFinish() {
                timerTextView.setText("Time's up!");
            }
        }.start();
    }

    public void onClickBtn(View v)
    {
        System.out.println("click");
        Toast.makeText(this, "Clicked on Button", Toast.LENGTH_LONG).show();
    }

    public void onClickBtnToStreet(View v)
    {
        gameState.setRound(gameState.getRound() + 1);
        Intent myIntent = new Intent(MapsActivity.this, myStreetView.class);
        myIntent.putExtra("gameState", gameState); //Optional parameters
        MapsActivity.this.startActivity(myIntent);
    }

    public void onClickBtnHint(View v)
    {
        if(!guessed) {
            Button myButton=(Button)findViewById(R.id.hintBtn);
            myButton.setVisibility(View.GONE);
            gameState.setHasTip(false);

            myPair<Double, Double> hintCoords = new myPair(gameState.getCoords().getFirst(), gameState.getCoords().getSecond());

            double limit = Math.min(30, (double)(200 / (Math.abs(hintCoords.getFirst()) / 2)));
            hintCoords.setFirst(hintCoords.getFirst() + (Math.random() * (limit - (-limit) + 1) + (-limit)));

            hintCoords.setSecond(hintCoords.getSecond() + (Math.random() * (17 - (-17) + 1) + (-17)));

            LatLng hintLatLng = new LatLng(hintCoords.getFirst(), hintCoords.getSecond());
            mMap.moveCamera(CameraUpdateFactory.newLatLng(hintLatLng));
            mMap.animateCamera(CameraUpdateFactory.zoomTo(4f));
        }

    }

    public void onClickBtnPlusTime(View v) {
        if(!guessed) {
            Button myButton = (Button) findViewById(R.id.plusTimeBtn);
            myButton.setVisibility(View.GONE);
            gameState.setHasPlusTime(false);

            gameState.setTimeLeft(Utility.timeLeftStart);
            mCountDownTimer.cancel();
            createCountDownTimer();
        }
    }

    public void onClickBtnMusic(View view) {
        MediaPlayer mediaPlayer = BackgroundSoundService.mediaPlayer;
        if(mediaPlayer.isPlaying()){
            mediaPlayer.pause();
        } else {
            mediaPlayer.start();
        }
    }

    public void onClickBtnGuess(View v)
    {
        if(!guessed) {
            Guessed();
        }
    }

    public void onClickBtnZoomout(View v)
    {
        mMap.animateCamera(CameraUpdateFactory.zoomTo(2f));
    }

    public void onClickBtnPlayAgain(View v)
    {
        gameState = new GameState("Player", 0, 0, 0, true, true, new myPair<Double, Double>(0.0, 0.0));
        gameState.setRound(gameState.getRound() + 1);
        Intent myIntent = new Intent(MapsActivity.this, myStreetView.class);
        myIntent.putExtra("gameState", gameState); //Optional parameters
        MapsActivity.this.startActivity(myIntent);

    }

    private void Guessed() {
        mMap.addMarker(new MarkerOptions()
                .position(new LatLng(gameState.getCoords().getFirst(), gameState.getCoords().getSecond()))
                .title("You were here")
                .icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_VIOLET)));

        Polyline line = mMap.addPolyline(new PolylineOptions()
                .add(new LatLng(gameState.getCoords().getFirst(), gameState.getCoords().getSecond()), choiceCoords)
                .width(7)
                .color(Color.RED));

        mMap.moveCamera(CameraUpdateFactory.newLatLng(new LatLng(gameState.getCoords().getFirst(), gameState.getCoords().getSecond())));
        mMap.animateCamera(CameraUpdateFactory.zoomTo(2f)); //2f = min zoom, 20f = max zoom

        Location loc1 = new Location("");
        loc1.setLatitude(gameState.getCoords().getFirst());
        loc1.setLongitude(gameState.getCoords().getSecond());

        Location loc2 = new Location("");
        loc2.setLatitude(choiceCoords.latitude);
        loc2.setLongitude(choiceCoords.longitude);

        float distanceInKm = loc1.distanceTo(loc2) / 1000;
        gameState.setScore(gameState.getScore() + (Math.max(0, Utility.maxScore - (int) distanceInKm)));
        scoreView.setText("" + gameState.getScore() + " ");

        Toast.makeText(this,"You were " + (int) distanceInKm + " km away!", Toast.LENGTH_LONG).show();

        lastMarker = null;
        guessed = true;

        Button myButton=(Button)findViewById(R.id.startBtn);
        myButton.setVisibility(View.VISIBLE);

        if(gameState.getRound() >= 5) {
            myButton=(Button)findViewById(R.id.startBtn);
            myButton.setVisibility(View.GONE);

            myButton=(Button)findViewById(R.id.playAgainBtn);
            myButton.setVisibility(View.VISIBLE);
        }
    }
}