using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006247 RID: 25159
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WheelTowerStageMedalItem : GridProxyAbstract<IWheelTowerMedalItemData>
	{
		// Token: 0x0603F6DE RID: 259806 RVA: 0x01042648 File Offset: 0x01040848
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMedalBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F6DF RID: 259807 RVA: 0x010427B4 File Offset: 0x010409B4
		protected override void OnStart()
		{
			this.ScoreTween.SetCurrentEase(LTweenEase.OutSine);
			this.ScoreTween.BindUpdateTween(new Action<int>(this.OnScoreTweenUpdate));
			this.ScoreTween.BindCompleteTween(new Action(this.OnScoreTweenComplete));
			this.SeqPlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x0603F6E0 RID: 259808 RVA: 0x0104280D File Offset: 0x01040A0D
		protected override void OnBeforeDestroy()
		{
			CustomPromise<bool> tweenPromise = this.TweenPromise;
			if (tweenPromise != null)
			{
				tweenPromise.SetResult(true);
			}
			this.TweenPromise = null;
			this.ScoreTween.Destroy();
		}

		// Token: 0x0603F6E1 RID: 259809 RVA: 0x01042834 File Offset: 0x01040A34
		public void SetPreviewMedalId(int oldMedalId)
		{
			this.IsPreviewing = true;
			this.PreviewMedalId = oldMedalId;
			IWheelTowerMedalGroupData groupData = this.GetGroupData();
			if (groupData != null)
			{
				this.RefreshDisplay(groupData);
			}
		}

		// Token: 0x0603F6E2 RID: 259810 RVA: 0x01042860 File Offset: 0x01040A60
		public override void Refresh(IWheelTowerMedalItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.ApplyFlags(data);
			IWheelTowerMedalGroupData medalGroupData = ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(data.GroupId);
			if (medalGroupData == null)
			{
				return;
			}
			this.RefreshScore(medalGroupData, gridIndex);
			this.RefreshDisplay(medalGroupData);
		}

		// Token: 0x0603F6E3 RID: 259811 RVA: 0x010428A0 File Offset: 0x01040AA0
		public UniTask PlayScoreTweenAsync()
		{
			WheelTowerStageMedalItem.<PlayScoreTweenAsync>d__14 <PlayScoreTweenAsync>d__;
			<PlayScoreTweenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayScoreTweenAsync>d__.<>4__this = this;
			<PlayScoreTweenAsync>d__.<>1__state = -1;
			<PlayScoreTweenAsync>d__.<>t__builder.Start<WheelTowerStageMedalItem.<PlayScoreTweenAsync>d__14>(ref <PlayScoreTweenAsync>d__);
			return <PlayScoreTweenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6E4 RID: 259812 RVA: 0x010428E4 File Offset: 0x01040AE4
		public UniTask PlayUnlockAsync()
		{
			WheelTowerStageMedalItem.<PlayUnlockAsync>d__15 <PlayUnlockAsync>d__;
			<PlayUnlockAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockAsync>d__.<>4__this = this;
			<PlayUnlockAsync>d__.<>1__state = -1;
			<PlayUnlockAsync>d__.<>t__builder.Start<WheelTowerStageMedalItem.<PlayUnlockAsync>d__15>(ref <PlayUnlockAsync>d__);
			return <PlayUnlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6E5 RID: 259813 RVA: 0x01042927 File Offset: 0x01040B27
		[NullableContext(2)]
		private IWheelTowerMedalGroupData GetGroupData()
		{
			if (this.ItemData == null)
			{
				return null;
			}
			return ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(this.ItemData.GroupId);
		}

		// Token: 0x0603F6E6 RID: 259814 RVA: 0x01042948 File Offset: 0x01040B48
		private void ApplyFlags(IWheelTowerMedalItemData data)
		{
			bool valueOrDefault = data.HideDetails.GetValueOrDefault();
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(!data.DisableInteract.GetValueOrDefault());
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!valueOrDefault);
		}

		// Token: 0x0603F6E7 RID: 259815 RVA: 0x0104299C File Offset: 0x01040B9C
		private void RefreshScore(IWheelTowerMedalGroupData groupData, int gridIndex)
		{
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText((gridIndex + 1).ToString("D2"), true);
			}
			this.CurrentScore = groupData.Progress;
			UUIText text2 = base.GetText(6);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(groupData.Progress.ToString(), true);
		}

		// Token: 0x0603F6E8 RID: 259816 RVA: 0x010429F8 File Offset: 0x01040BF8
		private void RefreshDisplay(IWheelTowerMedalGroupData groupData)
		{
			this.CurrentMedalId = groupData.CurrentMedalId;
			bool flag = groupData.CurrentMedalId == 0;
			int num = this.IsPreviewing ? this.PreviewMedalId : groupData.CurrentMedalId;
			bool flag2 = num == 0;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetUIActive(!flag2);
			}
			UUITexture texture2 = base.GetTexture(3);
			if (texture2 != null)
			{
				texture2.SetUIActive(!flag2);
			}
			if (flag2)
			{
				return;
			}
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(num);
			if (medalConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(medalConfigById.Value.Icon, base.GetTexture(5), null, null);
			base.SetTextureByPath(medalConfigById.Value.Background, base.GetTexture(3), null, null);
		}

		// Token: 0x0603F6E9 RID: 259817 RVA: 0x01042B0C File Offset: 0x01040D0C
		private void OnScoreTweenUpdate(int value)
		{
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			text.SetText(value.ToString(), true);
		}

		// Token: 0x0603F6EA RID: 259818 RVA: 0x01042B27 File Offset: 0x01040D27
		private void OnScoreTweenComplete()
		{
			CustomPromise<bool> tweenPromise = this.TweenPromise;
			this.TweenPromise = null;
			if (tweenPromise == null)
			{
				return;
			}
			tweenPromise.SetResult(true);
		}

		// Token: 0x0603F6EB RID: 259819 RVA: 0x01042B44 File Offset: 0x01040D44
		private void OnMedalBtnClick()
		{
			if (this.ItemData == null)
			{
				return;
			}
			WheelTowerMedalDetailViewData param = new WheelTowerMedalDetailViewData
			{
				GroupId = this.ItemData.GroupId,
				Index = base.GridIndex + 1
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerMedalDetailView, param, null);
		}

		// Token: 0x04023992 RID: 145810
		private const float ScoreTweenDuration = 0.7f;

		// Token: 0x04023993 RID: 145811
		[Nullable(2)]
		private IWheelTowerMedalItemData ItemData;

		// Token: 0x04023994 RID: 145812
		private int CurrentScore;

		// Token: 0x04023995 RID: 145813
		private int CurrentMedalId;

		// Token: 0x04023996 RID: 145814
		private bool IsPreviewing;

		// Token: 0x04023997 RID: 145815
		private int PreviewMedalId;

		// Token: 0x04023998 RID: 145816
		private readonly LguiIntTween ScoreTween = new LguiIntTween();

		// Token: 0x04023999 RID: 145817
		[Nullable(2)]
		private CustomPromise<bool> TweenPromise;

		// Token: 0x0402399A RID: 145818
		[Nullable(2)]
		private UiSequencePlayer SeqPlayer;
	}
}
