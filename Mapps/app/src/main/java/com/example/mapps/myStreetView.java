package com.example.mapps;

// import android.support.design.widget.FloatingActionButton;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
// import android.support.v7.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Parcelable;
import android.util.Pair;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.google.android.gms.maps.OnStreetViewPanoramaReadyCallback;
import com.google.android.gms.maps.StreetViewPanorama;
import com.google.android.gms.maps.SupportStreetViewPanoramaFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.StreetViewPanoramaCamera;
import com.google.android.gms.maps.model.StreetViewPanoramaLocation;
import com.google.android.gms.maps.model.StreetViewPanoramaOrientation;
import com.google.android.gms.maps.model.StreetViewSource;

public class myStreetView extends AppCompatActivity
        implements OnStreetViewPanoramaReadyCallback {

    private StreetViewPanorama mStreetViewPanorama;
    private GameState gameState;
    private boolean secondLocation = false;
    private boolean newLocation = false;
    myPair<Double, Double> correctCoords = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.my_street_view);

        newLocation = true;
        SupportStreetViewPanoramaFragment streetViewFragment =
                (SupportStreetViewPanoramaFragment) getSupportFragmentManager()
                        .findFragmentById(R.id.googleMapStreetView);
        streetViewFragment.getStreetViewPanoramaAsync(this);

        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                newLocation = false;
                secondLocation = !secondLocation;
                onStreetViewPanoramaReady(mStreetViewPanorama);
            }
        });

    }

    @Override
    public void onStreetViewPanoramaReady(StreetViewPanorama streetViewPanorama) {
        mStreetViewPanorama = streetViewPanorama;

        if(newLocation) {
            Utility.ReadCoords(this);
            correctCoords = Utility.GetRndCoords();

            //    if (secondLocation) {
            //       streetViewPanorama.setPosition(new LatLng( correctCoords.getFirst(), correctCoords.getFirst()), StreetViewSource.OUTDOOR);
            //   } else {
            //       streetViewPanorama.setPosition(new LatLng( correctCoords.getFirst(), correctCoords.getFirst()));
            //  }

            streetViewPanorama.setStreetNamesEnabled(false);
            streetViewPanorama.setPanningGesturesEnabled(true);
            streetViewPanorama.setZoomGesturesEnabled(true);
            streetViewPanorama.setUserNavigationEnabled(true);
            streetViewPanorama.animateTo(
                    new StreetViewPanoramaCamera.Builder().
                            orientation(new StreetViewPanoramaOrientation(20, 20))
                            .zoom(streetViewPanorama.getPanoramaCamera().zoom)
                            .build(), 2000);

            streetViewPanorama.setOnStreetViewPanoramaChangeListener(panoramaChangeListener);

            //
            Intent intent = getIntent();
            // float testFloat = intent.getFloatExtra("testVal", 0);
            gameState = new GameState((GameState) intent.getSerializableExtra("gameState"));
            //

            Toast.makeText(this, "Go!", Toast.LENGTH_LONG).show();
            gameState.setTimeLeft(Utility.timeLeftStart);
            gameState.SetCoords(new myPair<Double, Double>(correctCoords.getFirst(), correctCoords.getSecond()));

            new CountDownTimer(gameState.getTimeLeft(), 1000) {
                TextView textView = (TextView) findViewById(R.id.timerTextView);

                public void onTick(long millisUntilFinished) {
                    textView.setText(millisUntilFinished / 1000 / 60 + ":" + (60 - ((Utility.timeLeftStart - millisUntilFinished) / 1000 % 60)) + " ");
                    gameState.setTimeLeft(gameState.getTimeLeft() - 1000);
                }

                public void onFinish() {
                    textView.setText("Time's up!");
                }
            }.start();
        }

        if (secondLocation) {
            streetViewPanorama.setPosition(new LatLng(correctCoords.getFirst(), correctCoords.getSecond()), StreetViewSource.OUTDOOR);
        } else {
            streetViewPanorama.setPosition(new LatLng(correctCoords.getFirst(), correctCoords.getSecond()));
        }

      //  gameState.SetCoords(correctCoords);

    }

    private StreetViewPanorama.OnStreetViewPanoramaChangeListener panoramaChangeListener =
            new StreetViewPanorama.OnStreetViewPanoramaChangeListener() {
                @Override
                public void onStreetViewPanoramaChange(
                        StreetViewPanoramaLocation streetViewPanoramaLocation) {

                }
            };

    public void onClickBtnToMap(View v)
    {
        Intent myIntent = new Intent(myStreetView.this, MapsActivity.class);
        System.out.println(gameState.getCoords().getFirst());
        System.out.println(gameState.getTimeLeft());
        myIntent.putExtra("gameState", gameState); //Optional parameters
        myStreetView.this.startActivity(myIntent);
    }

    public void onClickBtnZoomin(View v)
    {
        mStreetViewPanorama.animateTo(
                new StreetViewPanoramaCamera.Builder()
                        .orientation(mStreetViewPanorama.getPanoramaCamera().getOrientation())
                        .zoom(mStreetViewPanorama.getPanoramaCamera().zoom + 1).build(), 300);
    }

    public void onClickBtnZoomout(View v)
    {
        mStreetViewPanorama.animateTo(
                new StreetViewPanoramaCamera.Builder()
                        .orientation(mStreetViewPanorama.getPanoramaCamera().getOrientation())
                        .zoom(mStreetViewPanorama.getPanoramaCamera().zoom - 1).build(), 300);
    }
}