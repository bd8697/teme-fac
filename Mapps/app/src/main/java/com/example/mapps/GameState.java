package com.example.mapps;

import android.util.Pair;

import com.google.android.gms.maps.model.Polyline;

import java.io.Serializable;

public class GameState implements Serializable {
    private String playerName;
    private int score;
    private long timeLeft;
    private int round;
    private boolean hasTip;
    private boolean hasPlusTime;
    private myPair<Double, Double> coords;

    public GameState(String name, int score, long timeLeft, int round, boolean hasTip, boolean hasPlusTime, myPair<Double, Double> coords) {
        this.playerName = name;
        this.score = score;
        this.timeLeft = timeLeft;
        this.round = round;
        this.hasTip = hasTip;
        this.hasPlusTime = hasPlusTime;
        this.coords = coords;
    }

    public GameState(GameState theState) {
        this.playerName = theState.playerName;
        this.score = theState.score;
        this.timeLeft = theState.timeLeft;
        this.round = theState.round;
        this.hasTip = theState.hasTip;
        this.hasPlusTime = theState.hasPlusTime;
        this.coords = theState.coords;
        this.coords.setFirst(theState.getCoords().getFirst());
      //  System.out.println("val here" + theState.getCoords().getFirst());
      //  System.out.println(theState.getTimeLeft());
        this.coords.setSecond(theState.coords.getSecond());
    }

    public String getName() {
        return playerName;
    }

    public void setName(String name) {
        this.playerName = name;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }

    public long getTimeLeft() {
        return timeLeft;
    }

    public void setTimeLeft(long timeLeft) {
        this.timeLeft = timeLeft;
    }

    public int getRound() {
        return round;
    }

    public void setRound(int round) {
        this.round = round;
    }

    public boolean HasTip() {
        return hasTip;
    }

    public void setHasTip(boolean hasTip) {
        this.hasTip = hasTip;
    }

    public boolean HasPlusTime() {
        return hasPlusTime;
    }

    public void setHasPlusTime(boolean hasPlusTime) {
        this.hasPlusTime = hasPlusTime;
    }

    public myPair<Double, Double> getCoords() {
        return coords;
    }

    public void SetCoords(myPair<Double, Double> coords) {
        this.coords = coords;
    }
}