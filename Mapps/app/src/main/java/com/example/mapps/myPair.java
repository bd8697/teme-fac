package com.example.mapps;

import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;

public class myPair<F extends Double, S extends Double> implements Parcelable, Serializable {
    protected myPair(Parcel in) {
    }

    private F first; //first member of pair
    private S second; //second member of pair

    public myPair(F first, S second) {
        this.first = first;
        this.second = second;
    }

    public void setFirst(F first) {
        this.first = first;
    }

    public void setSecond(S second) {
        this.second = second;
    }

    public F getFirst() {
        return first;
    }

    public S getSecond() {
        return second;
    }
    @Override
    public void writeToParcel(Parcel dest, int flags) {
    }

    @Override
    public int describeContents() {
        return 0;
    }

    public static final Creator<myPair<Double, Double>> CREATOR = new Creator<myPair<Double, Double>>() {
        @Override
        public myPair<Double, Double> createFromParcel(Parcel in) {
            return new myPair<Double, Double>(in);
        }

        @Override
        public myPair<Double, Double>[] newArray(int size) {
            return null; // no arrays
        }
    };
}
