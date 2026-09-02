using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001235 RID: 4661
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerNormalLevelChoseItem : GridProxyAbstract<BabelActivityLevelInfo>
{
	// Token: 0x06007C1A RID: 31770 RVA: 0x00209960 File Offset: 0x00207B60
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C1B RID: 31771 RVA: 0x00209B32 File Offset: 0x00207D32
	protected override void OnStart()
	{
		this.LevelPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06007C1C RID: 31772 RVA: 0x00209B48 File Offset: 0x00207D48
	[NullableContext(1)]
	public override void Refresh(BabelActivityLevelInfo data, bool isSelected, int gridIndex)
	{
		base.GetText(1).SetText((gridIndex + 1).ToString() ?? "", true);
		this.LevelId = data.LevelsId;
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(data.LevelsId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), babelTowerLevelConfig.NameText, Array.Empty<object>());
		if (!StringUtils.IsEmpty(babelTowerLevelConfig.DesText))
		{
			base.GetText(10).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), babelTowerLevelConfig.DesText, Array.Empty<object>());
		}
		else
		{
			base.GetText(10).SetUIActive(false);
		}
		base.SetTextureByPath(babelTowerLevelConfig.Texture, base.GetTexture(4), null, null);
		base.GetItem(3).SetUIActive(data.IsFinished && data.PassStar >= babelTowerLevelConfig.PassStar);
		long num = Singleton<MathUtils>.Instance.LongToNumber(data.UnlockTime);
		this.IsUnlock = ((double)num <= Singleton<TimeUtil>.Instance.GetServerTimeStamp());
		base.GetItem(7).SetUIActive(this.IsUnlock);
		base.GetItem(8).SetUIActive(!this.IsUnlock);
		if (this.IsUnlock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "BabelTowerLevelGoto", Array.Empty<object>());
		}
		else
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(((double)num - Singleton<TimeUtil>.Instance.GetServerTimeStamp()) * Singleton<TimeUtil>.Instance.Millisecond);
			base.GetText(9).SetText(remainTimeDataFormat.CountDownText ?? "", true);
		}
		if (!this.RedDotHaveBind)
		{
			this.RedDotHaveBind = true;
		}
		else
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevel, base.GetItem(6), this.LevelId);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerNewLevel, base.GetItem(6), null, this.LevelId);
		if (ModelBase<BabelTowerModel>.Instance.LevelChoseHandle == this.LevelId)
		{
			this.PlayLoopSequence();
			return;
		}
		this.StopLoopSequence();
	}

	// Token: 0x06007C1D RID: 31773 RVA: 0x00209D60 File Offset: 0x00207F60
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevel, base.GetItem(6), this.LevelId);
	}

	// Token: 0x06007C1E RID: 31774 RVA: 0x00209D7E File Offset: 0x00207F7E
	private void OnClickButton()
	{
		if (this.IsUnlock)
		{
			Action<int> onClickButtonCallBack = this.OnClickButtonCallBack;
			if (onClickButtonCallBack != null)
			{
				onClickButtonCallBack(this.LevelId);
			}
		}
		this.LevelPlayer.StopCurrentSequence(false, false);
	}

	// Token: 0x06007C1F RID: 31775 RVA: 0x00209DAC File Offset: 0x00207FAC
	public void PlayLoopSequence()
	{
		if (this.LevelPlayer.IsPlayingSequence("Loop_Diffculty"))
		{
			this.LevelPlayer.ReplaySequenceByKey("Loop_Diffculty");
			return;
		}
		this.LevelPlayer.PlayLevelSequenceByName("Loop_Diffculty", false, null, false);
	}

	// Token: 0x06007C20 RID: 31776 RVA: 0x00209DF7 File Offset: 0x00207FF7
	public void StopLoopSequence()
	{
		this.LevelPlayer.StopCurrentSequence(false, true);
	}

	// Token: 0x06007C21 RID: 31777 RVA: 0x00209E06 File Offset: 0x00208006
	public bool IsPlayingSequence()
	{
		return this.LevelPlayer.IsPlayingSequence("Loop_Diffculty");
	}

	// Token: 0x04003B5B RID: 15195
	private bool IsUnlock;

	// Token: 0x04003B5C RID: 15196
	private bool RedDotHaveBind;

	// Token: 0x04003B5D RID: 15197
	private int LevelId;

	// Token: 0x04003B5E RID: 15198
	public Action<int> OnClickButtonCallBack;

	// Token: 0x04003B5F RID: 15199
	private LevelSequencePlayer LevelPlayer;

	// Token: 0x0200759B RID: 30107
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028939 RID: 166201
		public const int Button = 0;

		// Token: 0x0402893A RID: 166202
		public const int IndexText = 1;

		// Token: 0x0402893B RID: 166203
		public const int NameText = 2;

		// Token: 0x0402893C RID: 166204
		public const int DoneItem = 3;

		// Token: 0x0402893D RID: 166205
		public const int BgTexture = 4;

		// Token: 0x0402893E RID: 166206
		public const int OptionText = 5;

		// Token: 0x0402893F RID: 166207
		public const int RedDotItem = 6;

		// Token: 0x04028940 RID: 166208
		public const int GoItem = 7;

		// Token: 0x04028941 RID: 166209
		public const int LockItem = 8;

		// Token: 0x04028942 RID: 166210
		public const int LockText = 9;

		// Token: 0x04028943 RID: 166211
		public const int NameDesText = 10;
	}
}
