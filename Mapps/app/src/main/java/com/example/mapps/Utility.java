package com.example.mapps;

import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;

public class Utility {

    private static ArrayList<HashMap<String, Double>> allCoords = new ArrayList<HashMap<String, Double>>();
    public static final long timeLeftStart = 1000 * 60 * 3;
    public static final int maxScore = 5000; //km
    
    public static void ReadCoords(myStreetView activity){
        try {
            JSONObject obj = new JSONObject(loadJSONFromAsset(activity));
            JSONArray jArry = obj.getJSONArray("coords");
            HashMap<String, Double> coordAux;

            for (int i = 0; i <jArry.length(); i++) {
                JSONObject jo_inside = jArry.getJSONObject(i);
                double lat_value = jo_inside.getDouble("lat");
                double long_value = jo_inside.getDouble("long");

                coordAux = new HashMap<String, Double>();
                coordAux.put("lat", lat_value);
                coordAux.put("long", long_value);

                allCoords.add(coordAux);
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    public static myPair<Double, Double> GetRndCoords() {

        int min = 0;
        int max = allCoords.size() - 1;
        int rnd = (int) (Math.random() * (max - min + 1) + min);

        //   System.out.println(allCoords.get(rnd)); //change coordAux value to Double and return that // also, you can delete entry from allCoords after it was chosen
        return new myPair<Double, Double>(allCoords.get(rnd).get("lat"), allCoords.get(rnd).get("long"));
    }

    public static String loadJSONFromAsset(myStreetView activity) {
        String json = null;
        try {
            InputStream is = activity.getAssets().open("Coords.json");
            int size = is.available();
            byte[] buffer = new byte[size];
            is.read(buffer);
            is.close();
            json = new String(buffer, "UTF-8");
        } catch (IOException ex) {
            ex.printStackTrace();
            return null;
        }
        return json;
    }


}
