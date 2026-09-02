using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200347A RID: 13434
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ResetTimeController : ControllerBase<ResetTimeController>
{
	// Token: 0x0601C55E RID: 116062 RVA: 0x0087CCD0 File Offset: 0x0087AED0
	protected unsafe override bool OnInit()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Timer;
		ELogAuthor author = ELogAuthor.YZ;
		string message = "ResetTimeController.OnInit";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PassSeconds", this.PassSeconds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LastInputTime", this.LastInputTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NowSeconds", Singleton<Time>.Instance.NowSeconds);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		this.TimerHandle = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.PassSeconds += 60;
			if (this.PassSeconds >= 172800 && Singleton<Time>.Instance.NowSeconds - this.LastInputTime > 3600.0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Timer;
				ELogAuthor author2 = ELogAuthor.YZ;
				string message2 = "ResetTimeController.Logout";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PassSeconds", this.PassSeconds);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("LastInputTime", this.LastInputTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("NowSeconds", Singleton<Time>.Instance.NowSeconds);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.ResetTime);
			}
		}, 60000f, 1f, null, null, true);
		return true;
	}

	// Token: 0x0601C55F RID: 116063 RVA: 0x0087CDAF File Offset: 0x0087AFAF
	public override bool Clear()
	{
		this.ResetTime();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		return true;
	}

	// Token: 0x0601C560 RID: 116064 RVA: 0x0087CDD4 File Offset: 0x0087AFD4
	private void OnInputAnyKey(bool press, FKey key)
	{
		this.LastInputTime = Singleton<Time>.Instance.NowSeconds;
	}

	// Token: 0x0601C561 RID: 116065 RVA: 0x0087CDE8 File Offset: 0x0087AFE8
	public unsafe void ResetTime()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Timer;
		ELogAuthor author = ELogAuthor.YZ;
		string message = "ResetTimeController.ResetTime";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PassSeconds", this.PassSeconds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LastInputTime", this.LastInputTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NowSeconds", Singleton<Time>.Instance.NowSeconds);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		this.PassSeconds = 0;
		this.LastInputTime = 0.0;
		UWorld world = GlobalData.World;
		if (world == null)
		{
			return;
		}
		world.ResetAllTimeSeconds(0f);
	}

	// Token: 0x0400E3DC RID: 58332
	public const int PLAY_TIME_SECONDS = 172800;

	// Token: 0x0400E3DD RID: 58333
	public const int AFK_TIME_SECONDS = 3600;

	// Token: 0x0400E3DE RID: 58334
	public const int UPDATE_INTERVAL = 60000;

	// Token: 0x0400E3DF RID: 58335
	private int PassSeconds;

	// Token: 0x0400E3E0 RID: 58336
	private double LastInputTime;

	// Token: 0x0400E3E1 RID: 58337
	[Nullable(2)]
	private TimerHandle TimerHandle;
}
