using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Render;
using CSharpScript.Game.World.Controller;
using UnrealEngine;

// Token: 0x020034DF RID: 13535
[NullableContext(1)]
[Nullable(0)]
public class WorldGlobal : IStaticVariableResetter
{
	// Token: 0x0601C95D RID: 117085 RVA: 0x008917D0 File Offset: 0x0088F9D0
	static WorldGlobal()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(WorldGlobal.CreateStaticDefaultValue), new Action(WorldGlobal.ResetStaticDefaultValue));
	}

	// Token: 0x0601C95E RID: 117086 RVA: 0x008917EF File Offset: 0x0088F9EF
	public static void CreateStaticDefaultValue()
	{
		WorldGlobal.SweepHitResult = null;
	}

	// Token: 0x0601C95F RID: 117087 RVA: 0x008917F7 File Offset: 0x0088F9F7
	public static void ResetStaticDefaultValue()
	{
		WorldGlobal.BeginTravelLoadMapDelegate = null;
		WorldGlobal.EndLoadTransitionMapHandler = null;
		WorldGlobal.BeginLoadMapHandler = null;
		WorldGlobal.EndLoadMapHandler = null;
		WorldGlobal.LoadStreamLevelHandler = null;
		WorldGlobal.UnLoadStreamLevelHandler = null;
		WorldGlobal.SweepHitResult = null;
	}

	// Token: 0x0601C960 RID: 117088 RVA: 0x00891824 File Offset: 0x0088FA24
	public static void Initialize()
	{
		GlobalData.GameInstance.场景加载通知器 = new ULoadMapNotify(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
		GlobalData.GameInstance.场景加载通知器.Clear();
		Action<string> callback;
		if ((callback = WorldGlobal.<>O.<0>__BeginTravelLoadMap) == null)
		{
			callback = (WorldGlobal.<>O.<0>__BeginTravelLoadMap = new Action<string>(WorldGlobal.BeginTravelLoadMap));
		}
		WorldGlobal.BeginTravelLoadMapDelegate = global::DelegateUtils.ToManualReleaseDelegate<FBeginTravelLoadMapDelegate>(callback);
		GlobalData.GameInstance.场景加载通知器.BindBeginTravelLoadMap(WorldGlobal.BeginTravelLoadMapDelegate);
		Action<string> callback2;
		if ((callback2 = WorldGlobal.<>O.<1>__AfterEnterTransitionMap) == null)
		{
			callback2 = (WorldGlobal.<>O.<1>__AfterEnterTransitionMap = new Action<string>(WorldGlobal.AfterEnterTransitionMap));
		}
		WorldGlobal.EndLoadTransitionMapHandler = global::DelegateUtils.ToManualReleaseDelegate<FEndLoadTransitionMapDelegate>(callback2);
		GlobalData.GameInstance.场景加载通知器.BindEndLoadTransitionMap(WorldGlobal.EndLoadTransitionMapHandler);
		Action<string> callback3;
		if ((callback3 = WorldGlobal.<>O.<2>__BeginLoadMap) == null)
		{
			callback3 = (WorldGlobal.<>O.<2>__BeginLoadMap = new Action<string>(WorldGlobal.BeginLoadMap));
		}
		WorldGlobal.BeginLoadMapHandler = global::DelegateUtils.ToManualReleaseDelegate<FBeginLoadMapDelegate>(callback3);
		GlobalData.GameInstance.场景加载通知器.BindBeginLoadMap(WorldGlobal.BeginLoadMapHandler);
		Action<string> callback4;
		if ((callback4 = WorldGlobal.<>O.<3>__EndLoadMap) == null)
		{
			callback4 = (WorldGlobal.<>O.<3>__EndLoadMap = new Action<string>(WorldGlobal.EndLoadMap));
		}
		WorldGlobal.EndLoadMapHandler = global::DelegateUtils.ToManualReleaseDelegate<FEndLoadMapDelegate>(callback4);
		GlobalData.GameInstance.场景加载通知器.BindEndLoadMap(WorldGlobal.EndLoadMapHandler);
		Action<int, FName, ULevelStreaming> callback5;
		if ((callback5 = WorldGlobal.<>O.<4>__LoadSubLevel) == null)
		{
			callback5 = (WorldGlobal.<>O.<4>__LoadSubLevel = new Action<int, FName, ULevelStreaming>(WorldGlobal.LoadSubLevel));
		}
		WorldGlobal.LoadStreamLevelHandler = global::DelegateUtils.ToManualReleaseDelegate<FLoadStreamLevelDelegate>(callback5);
		GlobalData.GameInstance.场景加载通知器.BindLoadStreamLevel(WorldGlobal.LoadStreamLevelHandler);
		Action<int, FName> callback6;
		if ((callback6 = WorldGlobal.<>O.<5>__UnLoadSubLevel) == null)
		{
			callback6 = (WorldGlobal.<>O.<5>__UnLoadSubLevel = new Action<int, FName>(WorldGlobal.UnLoadSubLevel));
		}
		WorldGlobal.UnLoadStreamLevelHandler = global::DelegateUtils.ToManualReleaseDelegate<FUnLoadStreamLevelDelegate>(callback6);
		GlobalData.GameInstance.场景加载通知器.BindUnLoadStreamLevel(WorldGlobal.UnLoadStreamLevelHandler);
	}

	// Token: 0x0601C961 RID: 117089 RVA: 0x008919AC File Offset: 0x0088FBAC
	public static void Clear()
	{
		Action<string> callBack;
		if ((callBack = WorldGlobal.<>O.<0>__BeginTravelLoadMap) == null)
		{
			callBack = (WorldGlobal.<>O.<0>__BeginTravelLoadMap = new Action<string>(WorldGlobal.BeginTravelLoadMap));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		Action<string> callBack2;
		if ((callBack2 = WorldGlobal.<>O.<1>__AfterEnterTransitionMap) == null)
		{
			callBack2 = (WorldGlobal.<>O.<1>__AfterEnterTransitionMap = new Action<string>(WorldGlobal.AfterEnterTransitionMap));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack2);
		Action<string> callBack3;
		if ((callBack3 = WorldGlobal.<>O.<2>__BeginLoadMap) == null)
		{
			callBack3 = (WorldGlobal.<>O.<2>__BeginLoadMap = new Action<string>(WorldGlobal.BeginLoadMap));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack3);
		Action<string> callBack4;
		if ((callBack4 = WorldGlobal.<>O.<3>__EndLoadMap) == null)
		{
			callBack4 = (WorldGlobal.<>O.<3>__EndLoadMap = new Action<string>(WorldGlobal.EndLoadMap));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack4);
		Action<int, FName, ULevelStreaming> callBack5;
		if ((callBack5 = WorldGlobal.<>O.<4>__LoadSubLevel) == null)
		{
			callBack5 = (WorldGlobal.<>O.<4>__LoadSubLevel = new Action<int, FName, ULevelStreaming>(WorldGlobal.LoadSubLevel));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack5);
		Action<int, FName> callBack6;
		if ((callBack6 = WorldGlobal.<>O.<5>__UnLoadSubLevel) == null)
		{
			callBack6 = (WorldGlobal.<>O.<5>__UnLoadSubLevel = new Action<int, FName>(WorldGlobal.UnLoadSubLevel));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack6);
		GlobalData.GameInstance.场景加载通知器.Clear();
	}

	// Token: 0x0601C962 RID: 117090 RVA: 0x00891A88 File Offset: 0x0088FC88
	public static void LoadFromMap(int id)
	{
		AkiMapSource? akiMapSourceConfig = ConfigBase<WorldMapConfig>.Instance.GetAkiMapSourceConfig(id);
		if (akiMapSourceConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[WorldGlobal.LoadFromMap] 不存在Id:的AkiMapSourceConfig。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		WorldGlobal.OpenLevel(akiMapSourceConfig.Value.MapPath);
	}

	// Token: 0x0601C963 RID: 117091 RVA: 0x00891AEC File Offset: 0x0088FCEC
	public static void OpenLevel(string levelName)
	{
		if (ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel && ControllerBase<SeamlessTravelController>.Instance.StartTravel(levelName))
		{
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.ForceClientTravel && ModelBase<GameModeModel>.Instance.IsSameMapTraveling)
		{
			ModelBase<GameModeModel>.Instance.FlushTempDataLayers();
			RenderModuleModel instance = ModelBase<RenderModuleModel>.Instance;
			if (instance != null)
			{
				instance.FlushTempDependenciesNotMatchDataLayers();
			}
			WorldGlobal.BeginLoadMap(levelName);
			WorldGlobal.EndLoadMap(levelName);
			return;
		}
		WorldGlobal.PlayerClientTravel(Global.PlayerController, levelName);
	}

	// Token: 0x0601C964 RID: 117092 RVA: 0x00891B60 File Offset: 0x0088FD60
	public static void PlayerClientTravel(APlayerController playerController, string url)
	{
		playerController.ClientTravel(url, ETravelType.TRAVEL_Relative, true, default(FGuid));
	}

	// Token: 0x0601C965 RID: 117093 RVA: 0x00891B80 File Offset: 0x0088FD80
	public static void ToUeInt32Array([Nullable(2)] IList<int> inItems, TArray<int> outItems)
	{
		outItems.Empty(true);
		if (inItems == null)
		{
			return;
		}
		foreach (int value in inItems)
		{
			outItems.Add(value);
		}
	}

	// Token: 0x0601C966 RID: 117094 RVA: 0x00891BD4 File Offset: 0x0088FDD4
	public static void ToUeInt64Array([Nullable(2)] IList<long> inItems, TArray<long> outItems)
	{
		outItems.Empty(true);
		if (inItems == null)
		{
			return;
		}
		foreach (long value in inItems)
		{
			outItems.Add(value);
		}
	}

	// Token: 0x0601C967 RID: 117095 RVA: 0x00891C28 File Offset: 0x0088FE28
	public static void ToUeFloatArray([Nullable(2)] IList<float> inItems, TArray<float> outItems)
	{
		outItems.Empty(true);
		if (inItems == null)
		{
			return;
		}
		foreach (float value in inItems)
		{
			outItems.Add(value);
		}
	}

	// Token: 0x0601C968 RID: 117096 RVA: 0x00891C7C File Offset: 0x0088FE7C
	public static void ToUeStringArray([Nullable(new byte[]
	{
		2,
		1
	})] IList<string> inItems, TArray<string> outItems)
	{
		outItems.Empty(true);
		if (inItems == null)
		{
			return;
		}
		foreach (string value in inItems)
		{
			outItems.Add(value);
		}
	}

	// Token: 0x0601C969 RID: 117097 RVA: 0x00891CD0 File Offset: 0x0088FED0
	public static void ToTsArray<[Nullable(2)] T>([Nullable(new byte[]
	{
		2,
		1
	})] TArray<T> inItems, IList<T> outItems)
	{
		if (inItems == null)
		{
			outItems.Clear();
			return;
		}
		int num = inItems.Num();
		outItems.Clear();
		for (int i = 0; i < num; i++)
		{
			outItems.Add(inItems.Get(i));
		}
	}

	// Token: 0x0601C96A RID: 117098 RVA: 0x00891D0D File Offset: 0x0088FF0D
	public static void ResetArraySize<[Nullable(2)] T>(TArray<T> items, int newSize, T defaultValue)
	{
		while (items.Num() > newSize)
		{
			items.RemoveAt(items.Num() - 1);
		}
		while (items.Num() < newSize)
		{
			items.Add(defaultValue);
		}
	}

	// Token: 0x0601C96B RID: 117099 RVA: 0x00891D3A File Offset: 0x0088FF3A
	public static void ResetTsArraySize<[Nullable(2)] T>(List<T> items, int newSize, T defaultValue)
	{
		while (items.Count > newSize)
		{
			items.RemoveAt(items.Count - 1);
		}
		while (items.Count < newSize)
		{
			items.Add(defaultValue);
		}
	}

	// Token: 0x0601C96C RID: 117100 RVA: 0x00891D67 File Offset: 0x0088FF67
	public static Aki.Protocol.Vector ToTsVector(FVectorDouble value)
	{
		return new Aki.Protocol.Vector
		{
			X = (float)value.X,
			Y = (float)value.Y,
			Z = (float)value.Z
		};
	}

	// Token: 0x0601C96D RID: 117101 RVA: 0x00891D95 File Offset: 0x0088FF95
	public static Aki.Protocol.Vector ToTsVector(IVector value)
	{
		return new Aki.Protocol.Vector
		{
			X = (float)value.X,
			Y = (float)value.Y,
			Z = (float)value.Z
		};
	}

	// Token: 0x0601C96E RID: 117102 RVA: 0x00891DC3 File Offset: 0x0088FFC3
	[NullableContext(2)]
	public static FVector ToUeVectorOld(Aki.Protocol.Vector value)
	{
		if (value == null)
		{
			return global::Vector.ZeroVector;
		}
		return new FVector(value.X, value.Y, value.Z);
	}

	// Token: 0x0601C96F RID: 117103 RVA: 0x00891DE5 File Offset: 0x0088FFE5
	[NullableContext(2)]
	public static FVectorDouble ToUeVector(IVector value)
	{
		if (value == null)
		{
			return global::Vector.ZeroVectorDouble;
		}
		return new FVectorDouble(value.X, value.Y, value.Z);
	}

	// Token: 0x0601C970 RID: 117104 RVA: 0x00891E07 File Offset: 0x00890007
	public static Aki.Protocol.Rotator ToTsRotator(FRotator value)
	{
		Aki.Protocol.Rotator rotator = Aki.Protocol.Rotator.Create();
		rotator.Pitch = value.Pitch;
		rotator.Yaw = value.Yaw;
		rotator.Roll = value.Roll;
		return rotator;
	}

	// Token: 0x0601C971 RID: 117105 RVA: 0x00891E32 File Offset: 0x00890032
	[NullableContext(2)]
	public static FRotator ToUeRotator(Aki.Protocol.Rotator value)
	{
		if (value == null)
		{
			return new FRotator();
		}
		return new FRotator(value.Pitch, value.Yaw, value.Roll);
	}

	// Token: 0x0601C972 RID: 117106 RVA: 0x00891E54 File Offset: 0x00890054
	public static FGameplayAttributeData ToUeGameplayAttribute([Nullable(2)] GameplayAttributeData attribute)
	{
		FGameplayAttributeData fgameplayAttributeData = new FGameplayAttributeData();
		if (attribute == null)
		{
			return fgameplayAttributeData;
		}
		fgameplayAttributeData.AttributeType = attribute.AttributeType;
		fgameplayAttributeData.BaseValue = (float)attribute.BaseValue;
		fgameplayAttributeData.CurrentValue = (float)attribute.CurrentValue;
		return fgameplayAttributeData;
	}

	// Token: 0x0601C973 RID: 117107 RVA: 0x00891E93 File Offset: 0x00890093
	public static void OnStatStart()
	{
		if (GlobalData.World == null || Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "STAT STARTFILE", null);
	}

	// Token: 0x0601C974 RID: 117108 RVA: 0x00891EB9 File Offset: 0x008900B9
	public static void OnStatStop()
	{
		if (GlobalData.World == null || Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "STAT STOPFILE", null);
	}

	// Token: 0x0601C975 RID: 117109 RVA: 0x00891EDF File Offset: 0x008900DF
	public static void ResetLoadTime()
	{
		if (GlobalData.World == null || Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "LoadTimes.TestTime 0", null);
	}

	// Token: 0x0601C976 RID: 117110 RVA: 0x00891F05 File Offset: 0x00890105
	public static float GetLoadTime()
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return 0f;
		}
		return UKismetSystemLibrary.GetConsoleVariableFloatValue("LoadTimes.TestTime");
	}

	// Token: 0x0601C977 RID: 117111 RVA: 0x00891F23 File Offset: 0x00890123
	public static void LoadTimesCheckBegin(string groupName = "default")
	{
		if (GlobalData.World == null || Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "LoadTimes.TestSwitch 1", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "LoadTimes.DumpTest Start " + groupName, null);
	}

	// Token: 0x0601C978 RID: 117112 RVA: 0x00891F5F File Offset: 0x0089015F
	public static void LoadTimesCheckEnd()
	{
		if (GlobalData.World == null || Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "LoadTimes.DumpTest LOWTIME=-1", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "LoadTimes.TestSwitch 0", null);
	}

	// Token: 0x0601C979 RID: 117113 RVA: 0x00891F95 File Offset: 0x00890195
	private static void BeginTravelLoadMap(string mapName)
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.BeforeTravelMap);
	}

	// Token: 0x0601C97A RID: 117114 RVA: 0x00891FA7 File Offset: 0x008901A7
	private static void AfterEnterTransitionMap(string mapName)
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTransitionMap);
	}

	// Token: 0x0601C97B RID: 117115 RVA: 0x00891FB9 File Offset: 0x008901B9
	private static void BeginLoadMap(string mapName)
	{
		if (ModelBase<GameModeModel>.Instance.MapPath != mapName)
		{
			return;
		}
		ControllerBase<GameModeController>.Instance.BeforeLoadMap();
	}

	// Token: 0x0601C97C RID: 117116 RVA: 0x00891FD8 File Offset: 0x008901D8
	private static void EndLoadMap(string mapName)
	{
		if (GlobalData.World == null || !GlobalData.World.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "加载地图失败，因为World为空。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MapName", mapName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (ModelBase<GameModeModel>.Instance.MapPath != mapName)
		{
			return;
		}
		ControllerBase<GameModeController>.Instance.AfterLoadMap();
		Singleton<EventSystem>.Instance.Emit(EEventName.EndTravelMap);
	}

	// Token: 0x0601C97D RID: 117117 RVA: 0x0089204C File Offset: 0x0089024C
	[NullableContext(2)]
	private static void LoadSubLevel(int linkId, FName levelName, ULevelStreaming level)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "LoadStream完成。";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelName", levelName.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (GlobalData.World == null || !GlobalData.World.IsValid())
		{
			return;
		}
		ControllerBase<SubLevelController>.Instance.OnLoadSubLevel(linkId, levelName.ToString(), level);
	}

	// Token: 0x0601C97E RID: 117118 RVA: 0x008920B8 File Offset: 0x008902B8
	private unsafe static void UnLoadSubLevel(int linkId, FName levelName)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "UnLoadStream完成。";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LinkId", linkId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LevelName", levelName.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (GlobalData.World == null || !GlobalData.World.IsValid())
		{
			return;
		}
		ControllerBase<SubLevelController>.Instance.OnUnLoadSubLevel(linkId, levelName.ToString());
	}

	// Token: 0x0400E643 RID: 58947
	public const float RAY_DISTANCE = 200f;

	// Token: 0x0400E644 RID: 58948
	public const int ONE_SECOND_FOR_MILLISECOND = 1000;

	// Token: 0x0400E645 RID: 58949
	public const int ONE_METER_FOR_CENTIMETER = 100;

	// Token: 0x0400E646 RID: 58950
	[Nullable(2)]
	private static FBeginTravelLoadMapDelegate BeginTravelLoadMapDelegate;

	// Token: 0x0400E647 RID: 58951
	[Nullable(2)]
	private static FEndLoadTransitionMapDelegate EndLoadTransitionMapHandler;

	// Token: 0x0400E648 RID: 58952
	[Nullable(2)]
	private static FBeginLoadMapDelegate BeginLoadMapHandler;

	// Token: 0x0400E649 RID: 58953
	[Nullable(2)]
	private static FEndLoadMapDelegate EndLoadMapHandler;

	// Token: 0x0400E64A RID: 58954
	[Nullable(2)]
	private static FLoadStreamLevelDelegate LoadStreamLevelHandler;

	// Token: 0x0400E64B RID: 58955
	[Nullable(2)]
	private static FUnLoadStreamLevelDelegate UnLoadStreamLevelHandler;

	// Token: 0x0400E64C RID: 58956
	[Nullable(2)]
	public static FHitResult SweepHitResult;

	// Token: 0x02009697 RID: 38551
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031AF9 RID: 203513
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <0>__BeginTravelLoadMap;

		// Token: 0x04031AFA RID: 203514
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <1>__AfterEnterTransitionMap;

		// Token: 0x04031AFB RID: 203515
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <2>__BeginLoadMap;

		// Token: 0x04031AFC RID: 203516
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <3>__EndLoadMap;

		// Token: 0x04031AFD RID: 203517
		[Nullable(new byte[]
		{
			0,
			2
		})]
		public static Action<int, FName, ULevelStreaming> <4>__LoadSubLevel;

		// Token: 0x04031AFE RID: 203518
		[Nullable(0)]
		public static Action<int, FName> <5>__UnLoadSubLevel;
	}
}
