using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E5 RID: 5093
[NullableContext(1)]
[Nullable(0)]
public class BusinessTravelRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06008D31 RID: 36145 RVA: 0x00252150 File Offset: 0x00250350
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
	}

	// Token: 0x06008D32 RID: 36146 RVA: 0x00252248 File Offset: 0x00250448
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishEvent), false);
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(4);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(5);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		UUIItem item5 = base.GetItem(6);
		if (item5 != null)
		{
			item5.SetUIActive(false);
		}
		UUIItem item6 = base.GetItem(1);
		if (item6 == null)
		{
			return;
		}
		item6.SetUIActive(false);
	}

	// Token: 0x06008D33 RID: 36147 RVA: 0x002522F0 File Offset: 0x002504F0
	protected override void OnBeforeDestroy()
	{
		this.SequencePlayer.Clear();
	}

	// Token: 0x06008D34 RID: 36148 RVA: 0x002522FD File Offset: 0x002504FD
	private void FinishEvent(string name)
	{
		if (name == "Action03")
		{
			this.HideDialog();
			this.SetSuccessItemActive(false);
			this.SetFailItemActive(false);
			this.SetNormalItemActive(false);
			this.HideFavorItem();
			this.SetLightItemActive(false);
		}
	}

	// Token: 0x06008D35 RID: 36149 RVA: 0x00252334 File Offset: 0x00250534
	private void SwitchRoleSpineAnim(ESpineAnimation animName, float mixDuration)
	{
		UTrackEntry utrackEntry = base.GetSpine(0).SetAnimation(0, animName.ToString(), true);
		if (utrackEntry == null)
		{
			return;
		}
		utrackEntry.SetMixDuration(mixDuration);
	}

	// Token: 0x06008D36 RID: 36150 RVA: 0x0025235C File Offset: 0x0025055C
	private void ShowDialog(string textId)
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, Array.Empty<object>());
	}

	// Token: 0x06008D37 RID: 36151 RVA: 0x00252388 File Offset: 0x00250588
	private void HideDialog()
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008D38 RID: 36152 RVA: 0x0025239C File Offset: 0x0025059C
	private void SetSuccessItemActive(bool value)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x06008D39 RID: 36153 RVA: 0x002523B0 File Offset: 0x002505B0
	private void SetFailItemActive(bool value)
	{
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x06008D3A RID: 36154 RVA: 0x002523C4 File Offset: 0x002505C4
	private void SetNormalItemActive(bool value)
	{
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x06008D3B RID: 36155 RVA: 0x002523D8 File Offset: 0x002505D8
	private void ShowFavorItem(int lastLevel)
	{
		EditTeamData editTeamDataById = ModelBase<MoonChasingBusinessModel>.Instance.GetEditTeamDataById(this.RoleId);
		if (editTeamDataById.Level > lastLevel)
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(7);
			if (text != null)
			{
				text.SetText(lastLevel.ToString(), true);
			}
			UUIText text2 = base.GetText(8);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(editTeamDataById.Level.ToString(), true);
		}
	}

	// Token: 0x06008D3C RID: 36156 RVA: 0x0025244E File Offset: 0x0025064E
	private void HideFavorItem()
	{
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008D3D RID: 36157 RVA: 0x00252462 File Offset: 0x00250662
	private void SetLightItemActive(bool value)
	{
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(value);
	}

	// Token: 0x06008D3E RID: 36158 RVA: 0x00252477 File Offset: 0x00250677
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		this.RoleId = roleId;
	}

	// Token: 0x06008D3F RID: 36159 RVA: 0x00252480 File Offset: 0x00250680
	public UniTask RefreshAsync()
	{
		BusinessTravelRoleItem.<RefreshAsync>d__17 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<BusinessTravelRoleItem.<RefreshAsync>d__17>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008D40 RID: 36160 RVA: 0x002524C4 File Offset: 0x002506C4
	public void PlayStartAction()
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_zuiyuejie_loading");
		this.SequencePlayer.PlayLevelSequenceByName("Action01", false, null, false);
		this.SwitchRoleSpineAnim(ESpineAnimation.Working, 0.1f);
		this.SetLightItemActive(true);
	}

	// Token: 0x06008D41 RID: 36161 RVA: 0x00252514 File Offset: 0x00250714
	public void PlayRunFinishAction(RoleSettleResult result, int lastLevel)
	{
		Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_zuiyuejie_loading", EAudioActionType.Stop, null);
		this.SequencePlayer.PlayLevelSequenceByName("Action02", false, null, false);
		EntrustRole entrustRoleById = ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(this.RoleId);
		if (result == RoleSettleResult.Good)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_zhuiyuejie_positive");
			this.ShowDialog(entrustRoleById.SuccessDialog);
			this.SwitchRoleSpineAnim(ESpineAnimation.Success, 0f);
			this.SetSuccessItemActive(true);
		}
		else if (result == RoleSettleResult.Bad)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_zhuiyuejie_passive");
			this.ShowDialog(entrustRoleById.FailDialog);
			this.SwitchRoleSpineAnim(ESpineAnimation.Fail, 0f);
			this.SetFailItemActive(true);
		}
		else
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_haoping");
			this.SwitchRoleSpineAnim(ESpineAnimation.Idle, 0f);
			this.SetNormalItemActive(true);
		}
		this.ShowFavorItem(lastLevel);
	}

	// Token: 0x06008D42 RID: 36162 RVA: 0x00252608 File Offset: 0x00250808
	public void PlayEndAction()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Action03", false, null, false);
	}

	// Token: 0x06008D43 RID: 36163 RVA: 0x00252630 File Offset: 0x00250830
	public void StopRunToLastFrame()
	{
		this.SequencePlayer.StopSequenceByKey("Action02", true, true);
	}

	// Token: 0x06008D44 RID: 36164 RVA: 0x00252644 File Offset: 0x00250844
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x040041C5 RID: 16837
	protected int RoleId;

	// Token: 0x040041C6 RID: 16838
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x020077DE RID: 30686
	[NullableContext(0)]
	private static class ERoleItem
	{
		// Token: 0x040293EE RID: 168942
		public const int RoleSpine = 0;

		// Token: 0x040293EF RID: 168943
		public const int DialogItem = 1;

		// Token: 0x040293F0 RID: 168944
		public const int Dialog = 2;

		// Token: 0x040293F1 RID: 168945
		public const int SuccessItem = 3;

		// Token: 0x040293F2 RID: 168946
		public const int FailItem = 4;

		// Token: 0x040293F3 RID: 168947
		public const int NormalItem = 5;

		// Token: 0x040293F4 RID: 168948
		public const int MultiLevelItem = 6;

		// Token: 0x040293F5 RID: 168949
		public const int MultiLevelBefore = 7;

		// Token: 0x040293F6 RID: 168950
		public const int MultiLevelAfter = 8;

		// Token: 0x040293F7 RID: 168951
		public const int LightItem = 9;
	}
}
