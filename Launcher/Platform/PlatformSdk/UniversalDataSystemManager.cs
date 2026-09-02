using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045CB RID: 17867
	[NullableContext(1)]
	[Nullable(0)]
	public class UniversalDataSystemManager
	{
		// Token: 0x0602ED11 RID: 191761 RVA: 0x00B16104 File Offset: 0x00B14304
		public void Initialize(string userId)
		{
			this.UserId = userId;
			UKuroStaticPS5Library.InitNpUniversalDataSystem(this.PoolSize);
			this.IsRegistered = false;
		}

		// Token: 0x0602ED12 RID: 191762 RVA: 0x00B16120 File Offset: 0x00B14320
		public void Start()
		{
			this.CreateContext();
			this.CreateHandle();
			this.RegisterContext();
		}

		// Token: 0x0602ED13 RID: 191763 RVA: 0x00B16134 File Offset: 0x00B14334
		public void Stop()
		{
			this.AbortHandle();
			this.DestroyHandle();
			this.DestroyContext();
		}

		// Token: 0x0602ED14 RID: 191764 RVA: 0x00B16148 File Offset: 0x00B14348
		private void CreateHandle()
		{
			if (this.UserId == null)
			{
				Singleton<LauncherLog>.Instance.Debug("UniversalDataSystemManager: CreateHandle Fail!!! UserId Is Empty", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int handle = 0;
			int num = UKuroStaticPS5Library.CreateUdsHandle(ref handle);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: CreateUdsHandle Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Handle = handle;
		}

		// Token: 0x0602ED15 RID: 191765 RVA: 0x00B161B4 File Offset: 0x00B143B4
		private void AbortHandle()
		{
			int num = UKuroStaticPS5Library.AbortUdsHandle(this.Handle);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: AbortUdsHandle Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0602ED16 RID: 191766 RVA: 0x00B161F8 File Offset: 0x00B143F8
		private void DestroyHandle()
		{
			int num = UKuroStaticPS5Library.DestroyUdsHandle(this.Handle);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: DestroyUdsHandle Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Handle = -1;
		}

		// Token: 0x0602ED17 RID: 191767 RVA: 0x00B16244 File Offset: 0x00B14444
		private void RegisterContext()
		{
			int num = UKuroStaticPS5Library.RegisterUdsContext(this.Context, this.Handle);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: RegisterUdsContext Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsRegistered = true;
		}

		// Token: 0x0602ED18 RID: 191768 RVA: 0x00B16298 File Offset: 0x00B14498
		private void CreateContext()
		{
			if (this.UserId == null)
			{
				Singleton<LauncherLog>.Instance.Debug("UniversalDataSystemManager: CreateUdsContext Fail!!! UserId Is Empty", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int context = this.Context;
			int num = UKuroStaticPS5Library.CreateUdsContext(ref this.UserId, ref context);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: CreateUdsContext Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.Context = context;
		}

		// Token: 0x0602ED19 RID: 191769 RVA: 0x00B16310 File Offset: 0x00B14510
		private void DestroyContext()
		{
			if (this.Context == -1)
			{
				Singleton<LauncherLog>.Instance.Debug("UniversalDataSystemManager: DestroyUdsContext Fail!!! Context Is Empty", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num = UKuroStaticPS5Library.DestroyUdsContext(this.Context);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: DestroyUdsContext Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.IsRegistered = false;
		}

		// Token: 0x0602ED1A RID: 191770 RVA: 0x00B16380 File Offset: 0x00B14580
		[return: Nullable(2)]
		private EventData CreateEvent(string eventName)
		{
			long eventPtr = 0L;
			long proPtr = 0L;
			int num = UKuroStaticPS5Library.CreateUdsEvent(ref eventName, ref eventPtr, ref proPtr);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: CreateUdsEvent Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			EventData eventData = new EventData();
			eventData.EventName = eventName;
			eventData.EventPtr = eventPtr;
			eventData.ProPtr = proPtr;
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UniversalDataSystemManager: CreateUdsEvent Success";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("eventName", eventName);
			instance2.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return eventData;
		}

		// Token: 0x0602ED1B RID: 191771 RVA: 0x00B1640C File Offset: 0x00B1460C
		private unsafe void PostEvent(EventData eventData)
		{
			int num = UKuroStaticPS5Library.PostUdsEvent(this.Context, this.Handle, eventData.EventPtr);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: PostUdsEvent Fail";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", eventData.EventName);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UniversalDataSystemManager: PostUdsEvent Success";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("eventName", eventData.EventName);
			instance2.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602ED1C RID: 191772 RVA: 0x00B164B8 File Offset: 0x00B146B8
		private void DestroyEvent(EventData eventData)
		{
			int num = UKuroStaticPS5Library.DestroyUdsEvent(eventData.EventPtr);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: DestroyUdsEvent Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", num);
				instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UniversalDataSystemManager: DestroyUdsEvent Success";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("eventName", eventData.EventName);
			instance2.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x0602ED1D RID: 191773 RVA: 0x00B16528 File Offset: 0x00B14728
		private unsafe void EventPropertyObjectSetString(EventData eventData, string key, string value)
		{
			int num = UKuroStaticPS5Library.UdsEventPropertyObjectSetString(eventData.ProPtr, ref key, ref value);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: EventPropertyObjectSetString Fail";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("value", value);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UniversalDataSystemManager: EventPropertyObjectSetString Success";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("eventName", eventData.EventName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("value", value);
			instance2.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}

		// Token: 0x0602ED1E RID: 191774 RVA: 0x00B16624 File Offset: 0x00B14824
		private unsafe void EventPropertyArraySetString(EventData eventData, string key, TArray<string> value)
		{
			int num = UKuroStaticPS5Library.UdsEventPropertyArraySetString(eventData.ProPtr, ref key, ref value);
			if (num != 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "UniversalDataSystemManager: EventPropertyArraySetString Fail";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("value", value);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "UniversalDataSystemManager: EventPropertyArraySetString Success";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("eventName", eventData.EventName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("value", value);
			instance2.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}

		// Token: 0x0602ED1F RID: 191775 RVA: 0x00B16720 File Offset: 0x00B14920
		public void StartActivity(string activityId)
		{
			EventData eventData = this.CreateEvent("activityStart");
			if (eventData != null)
			{
				this.EventPropertyObjectSetString(eventData, "activityId", activityId);
				this.PostEvent(eventData);
				this.DestroyEvent(eventData);
			}
		}

		// Token: 0x0602ED20 RID: 191776 RVA: 0x00B16758 File Offset: 0x00B14958
		public void EndActivity(string activityId, EPsActivityEndActivityOutcome outcome = EPsActivityEndActivityOutcome.Completed)
		{
			EventData eventData = this.CreateEvent("activityEnd");
			if (eventData != null)
			{
				this.EventPropertyObjectSetString(eventData, "activityId", activityId);
				this.EventPropertyObjectSetString(eventData, "outcome", outcome.ToEnumString());
				this.PostEvent(eventData);
				this.DestroyEvent(eventData);
			}
		}

		// Token: 0x0602ED21 RID: 191777 RVA: 0x00B167A4 File Offset: 0x00B149A4
		public void ChangeActivityAvailability([Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> availableActivities, [Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> unavailableActivities)
		{
			EventData eventData = this.CreateEvent("activityAvailabilityChange");
			if (eventData != null)
			{
				if (availableActivities != null)
				{
					this.EventPropertyArraySetString(eventData, "availableActivities", availableActivities);
				}
				if (unavailableActivities != null)
				{
					this.EventPropertyArraySetString(eventData, "unavailableActivities", unavailableActivities);
				}
				this.EventPropertyObjectSetString(eventData, "mode", "full");
				this.PostEvent(eventData);
				this.DestroyEvent(eventData);
			}
		}

		// Token: 0x0602ED22 RID: 191778 RVA: 0x00B167FF File Offset: 0x00B149FF
		public int GetHandle()
		{
			return this.Handle;
		}

		// Token: 0x0602ED23 RID: 191779 RVA: 0x00B16807 File Offset: 0x00B14A07
		public int GetContext()
		{
			return this.Context;
		}

		// Token: 0x0602ED24 RID: 191780 RVA: 0x00B1680F File Offset: 0x00B14A0F
		public bool GetIsRegistered()
		{
			return this.IsRegistered;
		}

		// Token: 0x0401AA1C RID: 109084
		private const int SCE_NP_UNIVERSAL_DATA_SYSTEM_INVALID_CONTEXT = -1;

		// Token: 0x0401AA1D RID: 109085
		private const int SCE_NP_UNIVERSAL_DATA_SYSTEM_INVALID_HANDLE = -1;

		// Token: 0x0401AA1E RID: 109086
		private const int UNIVERSAL_DATA_SYSTEM_MEMORY_POOL_SIZE = 262144;

		// Token: 0x0401AA1F RID: 109087
		private const int SCE_OK = 0;

		// Token: 0x0401AA20 RID: 109088
		private int Context = -1;

		// Token: 0x0401AA21 RID: 109089
		private int Handle = -1;

		// Token: 0x0401AA22 RID: 109090
		private readonly int PoolSize = 262144;

		// Token: 0x0401AA23 RID: 109091
		private bool IsRegistered;

		// Token: 0x0401AA24 RID: 109092
		[Nullable(2)]
		private string UserId;
	}
}
