using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A42 RID: 19010
	public class UiActorPoolConfig : IStaticVariableResetter
	{
		// Token: 0x06031A99 RID: 203417 RVA: 0x00C5F4C4 File Offset: 0x00C5D6C4
		static UiActorPoolConfig()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiActorPoolConfig.CreateStaticDefaultValue), new Action(UiActorPoolConfig.ResetStaticDefaultValue));
		}

		// Token: 0x06031A9A RID: 203418 RVA: 0x00C5F4E4 File Offset: 0x00C5D6E4
		public static void CreateStaticDefaultValue()
		{
			IPrepareLoadStruct[] array = new IPrepareLoadStruct[21];
			int num = 0;
			PrepareLoadStruct prepareLoadStruct = new PrepareLoadStruct();
			prepareLoadStruct.ResourceId = "UiItem_NPCIcon_Prefab";
			prepareLoadStruct.CacheCount = (() => 30);
			array[num] = prepareLoadStruct;
			int num2 = 1;
			PrepareLoadStruct prepareLoadStruct2 = new PrepareLoadStruct();
			prepareLoadStruct2.ResourceId = "UiItem_Mark_Prefab";
			prepareLoadStruct2.CacheCount = (() => 2);
			array[num2] = prepareLoadStruct2;
			int num3 = 2;
			PrepareLoadStruct prepareLoadStruct3 = new PrepareLoadStruct();
			prepareLoadStruct3.ResourceId = "UiItem_MarkMapName_Prefab";
			prepareLoadStruct3.CacheCount = (() => 2);
			array[num3] = prepareLoadStruct3;
			int num4 = 3;
			PrepareLoadStruct prepareLoadStruct4 = new PrepareLoadStruct();
			prepareLoadStruct4.ResourceId = "UiItem_MarkArea_Prefab";
			prepareLoadStruct4.CacheCount = (() => 2);
			array[num4] = prepareLoadStruct4;
			int num5 = 4;
			PrepareLoadStruct prepareLoadStruct5 = new PrepareLoadStruct();
			prepareLoadStruct5.ResourceId = "UiItem_ProbeArea";
			prepareLoadStruct5.CacheCount = (() => 2);
			array[num5] = prepareLoadStruct5;
			int num6 = 5;
			PrepareLoadStruct prepareLoadStruct6 = new PrepareLoadStruct();
			prepareLoadStruct6.ResourceId = "UiItem_MarkChoose_Prefab";
			prepareLoadStruct6.CacheCount = (() => 2);
			array[num6] = prepareLoadStruct6;
			int num7 = 6;
			PrepareLoadStruct prepareLoadStruct7 = new PrepareLoadStruct();
			prepareLoadStruct7.ResourceId = "UiItem_MarkOut_Prefab";
			prepareLoadStruct7.CacheCount = (() => 2);
			array[num7] = prepareLoadStruct7;
			int num8 = 7;
			PrepareLoadStruct prepareLoadStruct8 = new PrepareLoadStruct();
			prepareLoadStruct8.ResourceId = "UiItem_MarkTrackNia_Prefab";
			prepareLoadStruct8.CacheCount = (() => 2);
			array[num8] = prepareLoadStruct8;
			int num9 = 8;
			PrepareLoadStruct prepareLoadStruct9 = new PrepareLoadStruct();
			prepareLoadStruct9.ResourceId = "UiItem_Map_Prefab";
			prepareLoadStruct9.CacheCount = (() => 0);
			array[num9] = prepareLoadStruct9;
			int num10 = 9;
			PrepareLoadStruct prepareLoadStruct10 = new PrepareLoadStruct();
			prepareLoadStruct10.ResourceId = "UiItem_MiniMap_Prefab";
			prepareLoadStruct10.CacheCount = (() => 1);
			array[num10] = prepareLoadStruct10;
			int num11 = 10;
			PrepareLoadStruct prepareLoadStruct11 = new PrepareLoadStruct();
			prepareLoadStruct11.ResourceId = "UiItem_WorldMapMark_Prefab";
			prepareLoadStruct11.CacheCount = (() => 1);
			array[num11] = prepareLoadStruct11;
			int num12 = 11;
			PrepareLoadStruct prepareLoadStruct12 = new PrepareLoadStruct();
			prepareLoadStruct12.ResourceId = "UiView_InteractionHint_Prefab";
			prepareLoadStruct12.CacheCount = (() => 1);
			array[num12] = prepareLoadStruct12;
			int num13 = 12;
			PrepareLoadStruct prepareLoadStruct13 = new PrepareLoadStruct();
			prepareLoadStruct13.ResourceId = "UiView_Roulette_Prefab";
			prepareLoadStruct13.CacheCount = (() => 1);
			array[num13] = prepareLoadStruct13;
			int num14 = 13;
			PrepareLoadStruct prepareLoadStruct14 = new PrepareLoadStruct();
			prepareLoadStruct14.ResourceId = "UiItem_SuoDing";
			prepareLoadStruct14.CacheCount = (() => 1);
			array[num14] = prepareLoadStruct14;
			int num15 = 14;
			PrepareLoadStruct prepareLoadStruct15 = new PrepareLoadStruct();
			prepareLoadStruct15.ResourceId = "UiItem_PartState_Prefab";
			prepareLoadStruct15.CacheCount = (() => 1);
			array[num15] = prepareLoadStruct15;
			int num16 = 15;
			PrepareLoadStruct prepareLoadStruct16 = new PrepareLoadStruct();
			prepareLoadStruct16.ResourceId = "UiView_AcquireIntro_Prefab";
			prepareLoadStruct16.CacheCount = (() => 1);
			array[num16] = prepareLoadStruct16;
			int num17 = 16;
			PrepareLoadStruct prepareLoadStruct17 = new PrepareLoadStruct();
			prepareLoadStruct17.ResourceId = "UiItem_ItemListA";
			prepareLoadStruct17.CacheCount = (() => 3);
			array[num17] = prepareLoadStruct17;
			int num18 = 17;
			PrepareLoadStruct prepareLoadStruct18 = new PrepareLoadStruct();
			prepareLoadStruct18.ResourceId = "UiItem_ItemListB";
			prepareLoadStruct18.CacheCount = (() => 4);
			array[num18] = prepareLoadStruct18;
			int num19 = 18;
			PrepareLoadStruct prepareLoadStruct19 = new PrepareLoadStruct();
			prepareLoadStruct19.ResourceId = "UiView_BlackScreen_Prefab";
			prepareLoadStruct19.CacheCount = (() => 1);
			array[num19] = prepareLoadStruct19;
			int num20 = 19;
			PrepareLoadStruct prepareLoadStruct20 = new PrepareLoadStruct();
			prepareLoadStruct20.ResourceId = "UiView_BlackFadeScreen_Prefab";
			prepareLoadStruct20.CacheCount = (() => 1);
			array[num20] = prepareLoadStruct20;
			int num21 = 20;
			PrepareLoadStruct prepareLoadStruct21 = new PrepareLoadStruct();
			prepareLoadStruct21.ResourceId = "UiItem_InteractionSpot";
			prepareLoadStruct21.CacheCount = (() => 1);
			array[num21] = prepareLoadStruct21;
			UiActorPoolConfig.PrepareConfigList = array;
		}

		// Token: 0x06031A9B RID: 203419 RVA: 0x00C5F9A1 File Offset: 0x00C5DBA1
		public static void ResetStaticDefaultValue()
		{
			UiActorPoolConfig.PrepareConfigList = null;
		}

		// Token: 0x0401CE78 RID: 118392
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IPrepareLoadStruct[] PrepareConfigList;
	}
}
