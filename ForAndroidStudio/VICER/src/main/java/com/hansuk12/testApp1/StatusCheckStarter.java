package com.hansuk12.testApp1;

import android.app.Activity;
import android.content.Intent;
import android.util.Log;

import com.unity3d.player.UnityPlayerActivity;

public final class StatusCheckStarter {
    static Activity myActivity;
    // Called From C# to get the Activity Instance
    public static void receiveActivityInstance(Activity tempActivity) {
        myActivity = tempActivity;
    }

    public static void StartCheckerService() {
        Log.e("IN START","Service");
        myActivity.startService(new Intent(myActivity, MyService.class));
    }
}
