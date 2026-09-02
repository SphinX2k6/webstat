using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001390 RID: 5008
[NullableContext(1)]
[Nullable(0)]
internal class PhantomCardItem : GridProxyAbstract<int>
{
	// Token: 0x060089B5 RID: 35253 RVA: 0x00243744 File Offset: 0x00241944
	public PhantomCardItem(ActivityMapTravelData activityBaseData)
	{
		this.ActivityBaseData = activityBaseData;
	}

	// Token: 0x060089B6 RID: 35254 RVA: 0x00243754 File Offset: 0x00241954
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060089B7 RID: 35255 RVA: 0x00243948 File Offset: 0x00241B48
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x060089B8 RID: 35256 RVA: 0x00243968 File Offset: 0x00241B68
	public override void Refresh(int phantomId, bool isSelected, int gridIndex)
	{
		this.PhantomId = phantomId;
		PhantomGain value = ConfigBase<ActivityMapTravelConfig>.Instance.GetPhantomConfig(this.PhantomId).Value;
		Aki.Config.MonsterInfo value2 = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(value.MonsterInfoId).Value;
		bool valueOrDefault = this.ActivityBaseData.PhantomDataMap.GetValueOrDefault(phantomId, false);
		base.GetItem(1).SetUIActive(!valueOrDefault);
		base.GetItem(2).SetUIActive(valueOrDefault);
		base.GetItem(7).SetUIActive(valueOrDefault);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.Name, Array.Empty<object>());
		base.SetTextureShowUntilLoaded(value.TexPhantom, base.GetTexture(6), null);
		this.RefreshTexture(value2.RarityId);
		if (valueOrDefault)
		{
			this.TryUnlockItem();
		}
	}

	// Token: 0x060089B9 RID: 35257 RVA: 0x00243A38 File Offset: 0x00241C38
	private void RefreshTexture(int rarity)
	{
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("T_TravelMapAct_PhantomRarity");
		defaultInterpolatedStringHandler.AppendFormatted<int>(rarity);
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(3), delegate(bool _)
		{
			base.GetTexture(3).SetSizeFromTexture();
		});
		foreach (ValueTuple<int, int> valueTuple in new ValueTuple<int, int>[]
		{
			new ValueTuple<int, int>(4, 1),
			new ValueTuple<int, int>(10, 2),
			new ValueTuple<int, int>(9, 3),
			new ValueTuple<int, int>(11, 4)
		})
		{
			int item = valueTuple.Item1;
			int item2 = valueTuple.Item2;
			base.GetTexture(item).SetUIActive(rarity == item2);
		}
	}

	// Token: 0x060089BA RID: 35258 RVA: 0x00243B08 File Offset: 0x00241D08
	private void TryUnlockItem()
	{
		if (!this.ActivityBaseData.SaveFirstCheckRedDotState(EMapTravelSaveFlag.PhantomCollectNewUnlock, this.PhantomId))
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Unlock", false, null, false);
		}
	}

	// Token: 0x060089BB RID: 35259 RVA: 0x00243B48 File Offset: 0x00241D48
	private void OnClickedButton()
	{
		PhantomGain? phantomConfig = ConfigBase<ActivityMapTravelConfig>.Instance.GetPhantomConfig(this.PhantomId);
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
		ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.NormalMonster, Array.Empty<int>(), phantomConfig.Value.MonsterInfoId);
	}

	// Token: 0x04004082 RID: 16514
	protected int PhantomId;

	// Token: 0x04004083 RID: 16515
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004084 RID: 16516
	protected ActivityMapTravelData ActivityBaseData;

	// Token: 0x02007730 RID: 30512
	[NullableContext(0)]
	private class ECardComponent
	{
		// Token: 0x040290A5 RID: 168101
		public const int Button = 0;

		// Token: 0x040290A6 RID: 168102
		public const int ItemLock = 1;

		// Token: 0x040290A7 RID: 168103
		public const int PanelNormal = 2;

		// Token: 0x040290A8 RID: 168104
		public const int TexBg = 3;

		// Token: 0x040290A9 RID: 168105
		public const int TexQuality1 = 4;

		// Token: 0x040290AA RID: 168106
		public const int TxtName = 5;

		// Token: 0x040290AB RID: 168107
		public const int TexMonster = 6;

		// Token: 0x040290AC RID: 168108
		public const int ItemDone = 7;

		// Token: 0x040290AD RID: 168109
		public const int ItemNew = 8;

		// Token: 0x040290AE RID: 168110
		public const int TexQuality3 = 9;

		// Token: 0x040290AF RID: 168111
		public const int TexQuality2 = 10;

		// Token: 0x040290B0 RID: 168112
		public const int TexQuality4 = 11;
	}
}
