using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001218 RID: 4632
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerHardLevelChoseItem : GridProxyAbstract<BabelActivityLevelInfo>
{
	// Token: 0x06007B03 RID: 31491 RVA: 0x00202588 File Offset: 0x00200788
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickResetButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B04 RID: 31492 RVA: 0x002028B0 File Offset: 0x00200AB0
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<BabelTowerHardLevelRoleItem, int>(base.GetHorizontalLayout(8), new Func<BabelTowerHardLevelRoleItem>(this.InitRoleItem), null, false, true);
		this.LevelPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06007B05 RID: 31493 RVA: 0x002028E4 File Offset: 0x00200AE4
	public override void Refresh(BabelActivityLevelInfo data, bool isSelected, int gridIndex)
	{
		base.GetText(2).SetText((gridIndex + 1).ToString() ?? "", true);
		this.LevelId = data.LevelsId;
		bool isFinished = data.IsFinished;
		base.GetItem(9).SetUIActive(false);
		base.GetItem(10).SetUIActive(false);
		int num = 1;
		for (int i = 0; i < data.MaxPassBuffSelection.Count; i++)
		{
			int id = data.MaxPassBuffSelection[i];
			BabelTowerBuff babelTowerBuff = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerBuff(id);
			if (num == 1)
			{
				base.GetItem(9).SetUIActive(true);
				base.SetTextureByPath(babelTowerBuff.Texture, base.GetTexture(15), null, null);
			}
			if (num == 2)
			{
				base.GetItem(10).SetUIActive(true);
				base.SetTextureByPath(babelTowerBuff.Texture, base.GetTexture(16), null, null);
			}
			num++;
		}
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(data.LevelsId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), babelTowerLevelConfig.NameText, Array.Empty<object>());
		base.SetTextureByPath(babelTowerLevelConfig.Texture, base.GetTexture(1), null, null);
		base.GetItem(5).SetUIActive(isFinished);
		base.GetItem(19).SetUIActive(isFinished);
		base.GetItem(6).SetUIActive(!isFinished);
		base.GetButton(11).RootUIComp.Get().SetUIActive(isFinished);
		if (isFinished)
		{
			base.GetText(7).SetText(data.PassStar.ToString() ?? "", true);
			GenericLayout<BabelTowerHardLevelRoleItem, int> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.RefreshByData(new List<int>(data.MaxPassRoleSelection), null, false);
			}
			base.GetText(4).SetText(Singleton<TimeUtil>.Instance.GetTimeDataFormatWithHour((double)data.MaxPassUseTime), true);
		}
		else
		{
			base.GetText(4).SetText("", true);
		}
		long num2 = Singleton<MathUtils>.Instance.LongToNumber(data.UnlockTime);
		this.IsUnlock = ((double)num2 <= Singleton<TimeUtil>.Instance.GetServerTimeStamp());
		base.GetItem(12).SetUIActive(this.IsUnlock);
		base.GetItem(13).SetUIActive(!this.IsUnlock);
		if (!this.IsUnlock)
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(((double)num2 - Singleton<TimeUtil>.Instance.GetServerTimeStamp()) * Singleton<TimeUtil>.Instance.Millisecond);
			base.GetText(14).SetText(remainTimeDataFormat.CountDownText ?? "", true);
		}
		if (!this.RedDotHaveBind)
		{
			this.RedDotHaveBind = true;
		}
		else
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevel, base.GetItem(17), this.LevelId);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerNewLevel, base.GetItem(17), null, this.LevelId);
		if (ModelBase<BabelTowerModel>.Instance.LevelChoseHandle == this.LevelId)
		{
			this.PlayLoopSequence();
			return;
		}
		this.StopLoopSequence();
	}

	// Token: 0x06007B06 RID: 31494 RVA: 0x00202BFB File Offset: 0x00200DFB
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevel, base.GetItem(17), this.LevelId);
	}

	// Token: 0x06007B07 RID: 31495 RVA: 0x00202C1A File Offset: 0x00200E1A
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

	// Token: 0x06007B08 RID: 31496 RVA: 0x00202C48 File Offset: 0x00200E48
	private void OnClickResetButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerResetView, this.LevelId, null);
	}

	// Token: 0x06007B09 RID: 31497 RVA: 0x00202C65 File Offset: 0x00200E65
	private BabelTowerHardLevelRoleItem InitRoleItem()
	{
		return new BabelTowerHardLevelRoleItem();
	}

	// Token: 0x06007B0A RID: 31498 RVA: 0x00202C6C File Offset: 0x00200E6C
	public void DisableButton()
	{
		base.GetButton(11).RootUIComp.Get().SetUIActive(false);
		base.GetItem(12).SetUIActive(false);
	}

	// Token: 0x06007B0B RID: 31499 RVA: 0x00202CA4 File Offset: 0x00200EA4
	public void PlayLoopSequence()
	{
		if (this.LevelPlayer.IsPlayingSequence("Loop_item"))
		{
			this.LevelPlayer.ReplaySequenceByKey("Loop_item");
			return;
		}
		this.LevelPlayer.PlayLevelSequenceByName("Loop_item", false, null, false);
	}

	// Token: 0x06007B0C RID: 31500 RVA: 0x00202CEF File Offset: 0x00200EEF
	public void StopLoopSequence()
	{
		this.LevelPlayer.StopCurrentSequence(false, true);
	}

	// Token: 0x06007B0D RID: 31501 RVA: 0x00202CFE File Offset: 0x00200EFE
	public bool IsPlayingSequence()
	{
		return this.LevelPlayer.IsPlayingSequence("Loop_item");
	}

	// Token: 0x04003AF9 RID: 15097
	private bool IsUnlock;

	// Token: 0x04003AFA RID: 15098
	private bool RedDotHaveBind;

	// Token: 0x04003AFB RID: 15099
	private int LevelId;

	// Token: 0x04003AFC RID: 15100
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<BabelTowerHardLevelRoleItem, int> RoleLayout;

	// Token: 0x04003AFD RID: 15101
	[Nullable(2)]
	public Action<int> OnClickButtonCallBack;

	// Token: 0x04003AFE RID: 15102
	[Nullable(2)]
	private LevelSequencePlayer LevelPlayer;

	// Token: 0x02007573 RID: 30067
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028856 RID: 165974
		public const int Button = 0;

		// Token: 0x04028857 RID: 165975
		public const int BgTexture = 1;

		// Token: 0x04028858 RID: 165976
		public const int IndexText = 2;

		// Token: 0x04028859 RID: 165977
		public const int NameText = 3;

		// Token: 0x0402885A RID: 165978
		public const int TimeText = 4;

		// Token: 0x0402885B RID: 165979
		public const int DoneItem = 5;

		// Token: 0x0402885C RID: 165980
		public const int NoneItem = 6;

		// Token: 0x0402885D RID: 165981
		public const int StarText = 7;

		// Token: 0x0402885E RID: 165982
		public const int RoleLayout = 8;

		// Token: 0x0402885F RID: 165983
		public const int BuffItem1 = 9;

		// Token: 0x04028860 RID: 165984
		public const int BuffItem2 = 10;

		// Token: 0x04028861 RID: 165985
		public const int ResetBtn = 11;

		// Token: 0x04028862 RID: 165986
		public const int GoItem = 12;

		// Token: 0x04028863 RID: 165987
		public const int LockItem = 13;

		// Token: 0x04028864 RID: 165988
		public const int OptionText = 14;

		// Token: 0x04028865 RID: 165989
		public const int BuffTexture1 = 15;

		// Token: 0x04028866 RID: 165990
		public const int BuffTexture2 = 16;

		// Token: 0x04028867 RID: 165991
		public const int RedDotItem = 17;

		// Token: 0x04028868 RID: 165992
		public const int TimeItem = 18;

		// Token: 0x04028869 RID: 165993
		public const int FinishedItem = 19;
	}
}
