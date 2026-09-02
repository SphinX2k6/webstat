using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022C9 RID: 8905
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleTechTreeInfoPanel : UiPanelBase
{
	// Token: 0x170014DF RID: 5343
	// (get) Token: 0x06010D8A RID: 69002 RVA: 0x0049C608 File Offset: 0x0049A808
	private bool IsLockByPlayerStatus
	{
		get
		{
			return ModelBase<MotorcycleDevelopModel>.Instance.IsSwitchTechTreePlayerLocked();
		}
	}

	// Token: 0x06010D8B RID: 69003 RVA: 0x0049C614 File Offset: 0x0049A814
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(14, new Action<EToggleState>(this.OnTogEachLevelClick))
		};
	}

	// Token: 0x06010D8C RID: 69004 RVA: 0x0049C7A0 File Offset: 0x0049A9A0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTechTreeInfoPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTechTreeInfoPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010D8D RID: 69005 RVA: 0x0049C7E3 File Offset: 0x0049A9E3
	protected override void OnBeforeDestroy()
	{
		MediaPlayer mediaPlayer = this.MediaPlayer;
		if (mediaPlayer != null)
		{
			mediaPlayer.Clear();
		}
		this.MediaPlayer = null;
		this.CancelLoad();
	}

	// Token: 0x06010D8E RID: 69006 RVA: 0x0049C804 File Offset: 0x0049AA04
	[NullableContext(1)]
	public UniTask RefreshAsync(MotorTechTreeNode treeNode)
	{
		MotorcycleTechTreeInfoPanel.<RefreshAsync>d__13 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.treeNode = treeNode;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<MotorcycleTechTreeInfoPanel.<RefreshAsync>d__13>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010D8F RID: 69007 RVA: 0x0049C850 File Offset: 0x0049AA50
	public void PlayChangeTween()
	{
		this.SeqPlayer.StopSequenceByKey("Change", false, false);
		this.SeqPlayer.PlayLevelSequenceByName("Change", false, null, false);
	}

	// Token: 0x06010D90 RID: 69008 RVA: 0x0049C88C File Offset: 0x0049AA8C
	private UniTask LoadMaterial()
	{
		MotorcycleTechTreeInfoPanel.<LoadMaterial>d__15 <LoadMaterial>d__;
		<LoadMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadMaterial>d__.<>4__this = this;
		<LoadMaterial>d__.<>1__state = -1;
		<LoadMaterial>d__.<>t__builder.Start<MotorcycleTechTreeInfoPanel.<LoadMaterial>d__15>(ref <LoadMaterial>d__);
		return <LoadMaterial>d__.<>t__builder.Task;
	}

	// Token: 0x06010D91 RID: 69009 RVA: 0x0049C8CF File Offset: 0x0049AACF
	private void CancelLoad()
	{
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleId = -1;
		}
	}

	// Token: 0x06010D92 RID: 69010 RVA: 0x0049C8F4 File Offset: 0x0049AAF4
	private void OnTogEachLevelClick(EToggleState toggleState)
	{
		if (this.Node == null)
		{
			return;
		}
		MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(this.Node.NodeId);
		if (motorTechConfig == null)
		{
			return;
		}
		List<IMotorTechLevelPoint> list = new List<IMotorTechLevelPoint>();
		for (int i = 0; i < motorTechConfig.Value.GetTechLvArray().Length; i++)
		{
			MotorTechLevelPoint motorTechLevelPoint = new MotorTechLevelPoint
			{
				TargetLevel = i + 1,
				CurLevel = this.Node.NodeLevel,
				Title = motorTechConfig.Value.Title
			};
			motorTechLevelPoint.Desc = ConfigBase<MotorConfig>.Instance.GetMotorTechLvConfig(motorTechConfig.Value.GetTechLvArray()[i]).Value.Desc;
			list.Add(motorTechLevelPoint);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleTechTreeLevelDetailView, list, null);
	}

	// Token: 0x06010D93 RID: 69011 RVA: 0x0049C9D4 File Offset: 0x0049ABD4
	private void OnConfirmBtnClick(int _)
	{
		if (this.Node == null)
		{
			return;
		}
		if (!ModelBase<MotorcycleDevelopModel>.Instance.CanUpgradeNode(this.Node))
		{
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.SelectMotorDevelopTab, EUiTabViewName.MotorcycleTaskTabView);
			return;
		}
		if (this.IsLockByPlayerStatus)
		{
			return;
		}
		ControllerBase<MotorcycleDevelopController>.Instance.RequestMotorTechLevelUp(this.Node.NodeId);
	}

	// Token: 0x06010D94 RID: 69012 RVA: 0x0049CA30 File Offset: 0x0049AC30
	private void OnHelpBtnClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(470);
	}

	// Token: 0x040084C7 RID: 33991
	private const float TAG_BG_ALPHA = 0.3f;

	// Token: 0x040084C8 RID: 33992
	private MotorTechTreeNode Node;

	// Token: 0x040084C9 RID: 33993
	private ButtonItem ConfirmBtnItem;

	// Token: 0x040084CA RID: 33994
	private FunctionalPanelConditionLock LockTipsItem;

	// Token: 0x040084CB RID: 33995
	private MediaPlayer MediaPlayer;

	// Token: 0x040084CC RID: 33996
	private int HandleId = -1;

	// Token: 0x040084CD RID: 33997
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008595 RID: 34197
	[NullableContext(0)]
	private class EMotorTechTreeInfoComponent
	{
		// Token: 0x0402D318 RID: 185112
		public const int TexSkillIcon = 0;

		// Token: 0x0402D319 RID: 185113
		public const int TxtName = 1;

		// Token: 0x0402D31A RID: 185114
		public const int SprTagIcon = 2;

		// Token: 0x0402D31B RID: 185115
		public const int SprTagBg = 3;

		// Token: 0x0402D31C RID: 185116
		public const int TxtTagName = 4;

		// Token: 0x0402D31D RID: 185117
		public const int TxtDesc = 5;

		// Token: 0x0402D31E RID: 185118
		public const int BtnConfirm = 6;

		// Token: 0x0402D31F RID: 185119
		public const int TxtCostNum = 7;

		// Token: 0x0402D320 RID: 185120
		public const int TexCostItemIcon = 8;

		// Token: 0x0402D321 RID: 185121
		public const int PnlVideo = 9;

		// Token: 0x0402D322 RID: 185122
		public const int TexVideo = 10;

		// Token: 0x0402D323 RID: 185123
		public const int PnlHint = 11;

		// Token: 0x0402D324 RID: 185124
		public const int PnlLockTips = 12;

		// Token: 0x0402D325 RID: 185125
		public const int PnlMaxTips = 13;

		// Token: 0x0402D326 RID: 185126
		public const int TogEachLevel = 14;
	}
}
