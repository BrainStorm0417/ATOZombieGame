using UnityEngine;
using System.Collections;

public class AN_NotificationProxy {

	private const string CLASS_NAME = "com.androidnative.features.notifications.LocalNotificationManager";
	
	private static void CallActivityFunction(string methodName, params object[] args) {
		AN_ProxyPool.CallStatic(CLASS_NAME, methodName, args);
	}

	// --------------------------------------
	// Toast Notification
	// --------------------------------------

	public static void ShowToastNotification(string text, int duration) {
		CallActivityFunction("ShowToastNotification", text, duration.ToString());
	}

	// --------------------------------------
	// Local Notifications
	// --------------------------------------

	public static void HideAllNotifications() {
		CallActivityFunction ("HideAllNotifications");
	}
	
	public static void requestCurrentAppLaunchNotificationId() { 
		CallActivityFunction("requestCurrentAppLaunchNotificationId");
	}

	public static void ScheduleLocalNotification(AndroidNotificationBuilder builder) {
		CallActivityFunction("ScheduleLocalNotification",
		                     builder.Title,
		                     builder.Message,
		                     builder.Time.ToString(),
		                     builder.Id.ToString(),
		                     builder.Icon,
		                     builder.Sound,
		                     builder.Vibration.ToString(),
		                     builder.ShowIfAppForeground.ToString(),
		                     builder.LargeIcon,
		                     builder.BigPicture == null ? string.Empty : System.Convert.ToBase64String(builder.BigPicture.EncodeToPNG()));
	}
	
	public static void CanselLocalNotification(int id) {
		CallActivityFunction("canselLocalNotification", id.ToString());
	}

	// --------------------------------------
	// Google Cloud Message
	// --------------------------------------

	public static void InitPushNotifications(string smallIcon, string largeIcon, string sound, bool vibration, bool showWhenAppForeground, bool replaceOldNotificationWithNew) {
		CallActivityFunction ("InitPushNotifications", smallIcon, largeIcon, sound, vibration.ToString(), showWhenAppForeground.ToString(), replaceOldNotificationWithNew.ToString());
	}
	
	public static void GCMRgisterDevice(string senderId) {
		CallActivityFunction("GCMRgisterDevice", senderId);
	}
	
	public static void GCMLoadLastMessage() {
		CallActivityFunction("GCMLoadLastMessage");
	}

	public static void GCMRemoveLastMessageInfo() {
		CallActivityFunction("GCMRemoveLastMessageInfo");
	}
}
