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
	// Token: 0x02006238 RID: 25144
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WheelTowerSeasonMedalItem : GridProxyAbstract<IWheelTowerMedalItemData>
	{
		// Token: 0x0603F684 RID: 259716 RVA: 0x01040528 File Offset: 0x0103E728
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMedalBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F685 RID: 259717 RVA: 0x010406D8 File Offset: 0x0103E8D8
		protected override void OnStart()
		{
			this.ProgressTween.SetCurrentEase(LTweenEase.OutSine);
			this.ProgressTween.BindUpdateTween(new Action<float>(this.OnProgressTweenUpdate));
			this.ProgressTween.BindCompleteTween(new Action(this.OnProgressTweenComplete));
			this.SeqPlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x0603F686 RID: 259718 RVA: 0x01040731 File Offset: 0x0103E931
		protected override void OnBeforeDestroy()
		{
			CustomPromise<bool> tweenPromise = this.TweenPromise;
			if (tweenPromise != null)
			{
				tweenPromise.SetResult(true);
			}
			this.TweenPromise = null;
			this.ProgressTween.Destroy();
		}

		// Token: 0x0603F687 RID: 259719 RVA: 0x01040758 File Offset: 0x0103E958
		public void SetPreviewMedalId(int medalId)
		{
			this.PreviewMedalId = medalId;
			IWheelTowerMedalGroupData groupData = this.GetGroupData();
			if (groupData != null)
			{
				this.RefreshAppearance(groupData);
			}
		}

		// Token: 0x0603F688 RID: 259720 RVA: 0x01040780 File Offset: 0x0103E980
		public override void Refresh(IWheelTowerMedalItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.ApplyFlags(data);
			IWheelTowerMedalGroupData medalGroupData = ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(data.GroupId);
			if (medalGroupData == null)
			{
				return;
			}
			bool uiactive = medalGroupData.CurrentMedalId == 0;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			this.RefreshProgress(medalGroupData);
			this.RefreshAppearance(medalGroupData);
		}

		// Token: 0x0603F689 RID: 259721 RVA: 0x010407F0 File Offset: 0x0103E9F0
		public UniTask PlayProgressTweenAsync()
		{
			WheelTowerSeasonMedalItem.<PlayProgressTweenAsync>d__13 <PlayProgressTweenAsync>d__;
			<PlayProgressTweenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayProgressTweenAsync>d__.<>4__this = this;
			<PlayProgressTweenAsync>d__.<>1__state = -1;
			<PlayProgressTweenAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalItem.<PlayProgressTweenAsync>d__13>(ref <PlayProgressTweenAsync>d__);
			return <PlayProgressTweenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F68A RID: 259722 RVA: 0x01040834 File Offset: 0x0103EA34
		public UniTask PlayUnlockAsync()
		{
			WheelTowerSeasonMedalItem.<PlayUnlockAsync>d__14 <PlayUnlockAsync>d__;
			<PlayUnlockAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockAsync>d__.<>4__this = this;
			<PlayUnlockAsync>d__.<>1__state = -1;
			<PlayUnlockAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalItem.<PlayUnlockAsync>d__14>(ref <PlayUnlockAsync>d__);
			return <PlayUnlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F68B RID: 259723 RVA: 0x01040877 File Offset: 0x0103EA77
		[NullableContext(2)]
		private IWheelTowerMedalGroupData GetGroupData()
		{
			if (this.ItemData == null)
			{
				return null;
			}
			return ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(this.ItemData.GroupId);
		}

		// Token: 0x0603F68C RID: 259724 RVA: 0x01040898 File Offset: 0x0103EA98
		private void ApplyFlags(IWheelTowerMedalItemData data)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(!data.DisableInteract.GetValueOrDefault());
			}
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!data.HideDetails.GetValueOrDefault());
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!data.IsLast.GetValueOrDefault());
		}

		// Token: 0x0603F68D RID: 259725 RVA: 0x01040910 File Offset: 0x0103EB10
		private void RefreshProgress(IWheelTowerMedalGroupData groupData)
		{
			int currentTarget = groupData.CurrentTarget;
			int num = (currentTarget > 0) ? Math.Min(groupData.Progress, currentTarget) : groupData.Progress;
			UUIText text = base.GetText(7);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("</color>/<color=#b3b3b3>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentTarget);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			float num2 = (currentTarget > 0) ? ((float)num / (float)currentTarget) : 0f;
			this.CurrentProgressRatio = num2;
			UUISprite sprite = base.GetSprite(8);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(num2);
		}

		// Token: 0x0603F68E RID: 259726 RVA: 0x010409C0 File Offset: 0x0103EBC0
		private void RefreshAppearance(IWheelTowerMedalGroupData groupData)
		{
			this.CurrentMedalId = groupData.CurrentMedalId;
			int num = (groupData.CurrentMedalId != 0) ? groupData.CurrentMedalId : groupData.NextMedalId;
			int id = (this.PreviewMedalId != 0) ? this.PreviewMedalId : num;
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(id);
			if (medalConfigById == null)
			{
				return;
			}
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(6);
			string name = medalConfigById.Value.Name;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("S");
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupData.SeasonId);
			instance.SetLocalTextNew(text, name, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
			base.SetTextureByPath(medalConfigById.Value.Icon, base.GetTexture(4), null, null);
			base.SetTextureByPath(medalConfigById.Value.Background, base.GetTexture(3), null, null);
		}

		// Token: 0x0603F68F RID: 259727 RVA: 0x01040AB4 File Offset: 0x0103ECB4
		private void OnProgressTweenUpdate(float value)
		{
			UUISprite sprite = base.GetSprite(8);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(value);
		}

		// Token: 0x0603F690 RID: 259728 RVA: 0x01040AC8 File Offset: 0x0103ECC8
		private void OnProgressTweenComplete()
		{
			CustomPromise<bool> tweenPromise = this.TweenPromise;
			this.TweenPromise = null;
			if (tweenPromise == null)
			{
				return;
			}
			tweenPromise.SetResult(true);
		}

		// Token: 0x0603F691 RID: 259729 RVA: 0x01040AE4 File Offset: 0x0103ECE4
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

		// Token: 0x04023935 RID: 145717
		private const float ProgressTweenDuration = 0.7f;

		// Token: 0x04023936 RID: 145718
		[Nullable(2)]
		private IWheelTowerMedalItemData ItemData;

		// Token: 0x04023937 RID: 145719
		private float CurrentProgressRatio;

		// Token: 0x04023938 RID: 145720
		private int CurrentMedalId;

		// Token: 0x04023939 RID: 145721
		private int PreviewMedalId;

		// Token: 0x0402393A RID: 145722
		private readonly LguiFloatTween ProgressTween = new LguiFloatTween();

		// Token: 0x0402393B RID: 145723
		[Nullable(2)]
		private CustomPromise<bool> TweenPromise;

		// Token: 0x0402393C RID: 145724
		[Nullable(2)]
		private UiSequencePlayer SeqPlayer;
	}
}
