using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.AdventureGuide;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2E RID: 23598
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonMapDefine : IStaticVariableResetter
	{
		// Token: 0x170097D3 RID: 38867
		// (get) Token: 0x0603BA3E RID: 244286 RVA: 0x00F1C614 File Offset: 0x00F1A814
		public static Dictionary<EDungeonSubType, InstanceDetectItemGetterData> InstanceDetectItemGetterDataMap
		{
			get
			{
				if (InstanceDungeonMapDefine._InstanceDetectItemGetterDataMap == null)
				{
					Dictionary<EDungeonSubType, InstanceDetectItemGetterData> dictionary = new Dictionary<EDungeonSubType, InstanceDetectItemGetterData>();
					dictionary[EDungeonSubType.MowingRisk] = new InstanceDetectItemGetterData
					{
						SubtitleTextIdGetter = new TInstanceSubtitleTextIdGetter(ControllerBase<ActivityMowingRiskController>.Instance.GetInstanceSubtitleTextIdByInstanceId),
						SubtitleArgsGetter = new TInstanceSubtitleArgsGetter(ControllerBase<ActivityMowingRiskController>.Instance.GetInstanceSubtitleArgsByInstanceId),
						CheckFinishedGetter = new TInstanceCheckFinishedGetter(ControllerBase<ActivityMowingRiskController>.Instance.CheckInstanceFinishedByInstanceId)
					};
					dictionary[EDungeonSubType.SolarSpeed] = new InstanceDetectItemGetterData
					{
						SubtitleTextIdGetter = new TInstanceSubtitleTextIdGetter(ControllerBase<ActivitySolarSpeedController>.Instance.GetInstanceSubtitleTextIdByInstanceId),
						SubtitleArgsGetter = new TInstanceSubtitleArgsGetter(ControllerBase<ActivitySolarSpeedController>.Instance.GetInstanceSubtitleArgsByInstanceId)
					};
					InstanceDungeonMapDefine._InstanceDetectItemGetterDataMap = dictionary;
				}
				return InstanceDungeonMapDefine._InstanceDetectItemGetterDataMap;
			}
		}

		// Token: 0x170097D4 RID: 38868
		// (get) Token: 0x0603BA3F RID: 244287 RVA: 0x00F1C6C2 File Offset: 0x00F1A8C2
		public static Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceViewGetterData> InstanceDungeonEntranceViewGetterDataMap
		{
			get
			{
				if (InstanceDungeonMapDefine._InstanceDungeonEntranceViewGetterDataMap == null)
				{
					Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceViewGetterData> dictionary = new Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceViewGetterData>();
					dictionary[EInstanceEntranceFlowType.MowingRisk] = new InstanceDungeonEntranceViewGetterData
					{
						DefaultSelectDataGetter = new TInstanceDungeonEntranceViewDefaultSelectDataGetter(ControllerBase<ActivityMowingRiskController>.Instance.GetEntranceViewDefaultSelectData)
					};
					InstanceDungeonMapDefine._InstanceDungeonEntranceViewGetterDataMap = dictionary;
				}
				return InstanceDungeonMapDefine._InstanceDungeonEntranceViewGetterDataMap;
			}
		}

		// Token: 0x0603BA40 RID: 244288 RVA: 0x00F1C6FD File Offset: 0x00F1A8FD
		static InstanceDungeonMapDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InstanceDungeonMapDefine.CreateStaticDefaultValue), new Action(InstanceDungeonMapDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603BA41 RID: 244289 RVA: 0x00F1C71C File Offset: 0x00F1A91C
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0603BA42 RID: 244290 RVA: 0x00F1C71E File Offset: 0x00F1A91E
		public static void ResetStaticDefaultValue()
		{
			InstanceDungeonMapDefine._InstanceDetectItemGetterDataMap = null;
			InstanceDungeonMapDefine._InstanceDungeonEntranceViewGetterDataMap = null;
		}

		// Token: 0x040218E3 RID: 137443
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EDungeonSubType, InstanceDetectItemGetterData> _InstanceDetectItemGetterDataMap;

		// Token: 0x040218E4 RID: 137444
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceViewGetterData> _InstanceDungeonEntranceViewGetterDataMap;
	}
}
