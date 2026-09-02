using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB3 RID: 23475
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceItem : UiPanelBase
	{
		// Token: 0x0603B62E RID: 243246 RVA: 0x00F0B3BC File Offset: 0x00F095BC
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as InstanceDungeonViewModelBase);
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B62F RID: 243247 RVA: 0x00F0B539 File Offset: 0x00F09739
		protected override void OnStart()
		{
			this.ExtendToggle = base.GetExtendToggle(0);
			this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnChallengeInstanceRedDot, new Action<int>(this.OnChallengeInstanceRedDot));
		}

		// Token: 0x0603B630 RID: 243248 RVA: 0x00F0B574 File Offset: 0x00F09774
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnChallengeInstanceRedDot, new Action<int>(this.OnChallengeInstanceRedDot));
		}

		// Token: 0x0603B631 RID: 243249 RVA: 0x00F0B592 File Offset: 0x00F09792
		private void OnChallengeInstanceRedDot(int instanceId)
		{
			if (this.InstanceId != instanceId)
			{
				return;
			}
			this.UpdateRedDot();
		}

		// Token: 0x0603B632 RID: 243250 RVA: 0x00F0B5A4 File Offset: 0x00F097A4
		[NullableContext(1)]
		public UUIText GetTitleText()
		{
			return base.GetText(2);
		}

		// Token: 0x0603B633 RID: 243251 RVA: 0x00F0B5B0 File Offset: 0x00F097B0
		public void Update(int data, bool isSelect, bool isShow)
		{
			this.InstanceId = data;
			this.ExtendToggle.SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.ExtendToggle.CanExecuteChange.Unbind();
			this.ExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
			if (isSelect && this.OnClickCallback != null)
			{
				this.OnClickCallback(this.InstanceId, this.ExtendToggle, null);
			}
			if (!isShow)
			{
				return;
			}
			this.UpdateLockOrFirstReward();
			this.UpdateLevel();
			this.UpdateIcon();
			this.UpdateTextureTransition();
			this.UpdateRedDot();
		}

		// Token: 0x0603B634 RID: 243252 RVA: 0x00F0B64C File Offset: 0x00F0984C
		private void UpdateLockOrFirstReward()
		{
			if (ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(this.InstanceId))
			{
				base.GetItem(3).SetUIActive(true);
				base.GetItem(4).SetUIActive(false);
				return;
			}
			if (this.ParentModel.IsFinishInstance(this.InstanceId))
			{
				base.GetItem(3).SetUIActive(false);
				base.GetItem(4).SetUIActive(true);
				return;
			}
			base.GetItem(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x0603B635 RID: 243253 RVA: 0x00F0B6D0 File Offset: 0x00F098D0
		private void UpdateLevel()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.InstanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
			Dictionary<int, string> dictionary = config.Value.SubTitle();
			if (dictionary == null || dictionary.Count <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "InstanceDungeonRecommendLevel", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
				return;
			}
			int? num = null;
			string textStringId = null;
			foreach (KeyValuePair<int, string> keyValuePair in dictionary)
			{
				int num2;
				string text;
				keyValuePair.Deconstruct(out num2, out text);
				int value = num2;
				string text2 = text;
				num = new int?(value);
				textStringId = text2;
			}
			if (num.GetValueOrDefault() == 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
				return;
			}
			if (num.GetValueOrDefault() == 2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RecommendLevel", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
			}
		}

		// Token: 0x0603B636 RID: 243254 RVA: 0x00F0B800 File Offset: 0x00F09A00
		private void UpdateIcon()
		{
			string instanceDetectItemIcon = this.ParentModel.GetInstanceDetectItemIcon(this.InstanceId);
			if (!string.IsNullOrWhiteSpace(instanceDetectItemIcon))
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				base.SetTextureByPath(instanceDetectItemIcon, base.GetTexture(1), null, null);
				return;
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603B637 RID: 243255 RVA: 0x00F0B868 File Offset: 0x00F09A68
		private void UpdateTextureTransition()
		{
			InstanceDungeonViewModelBase parentModel = this.ParentModel;
			string text = ((parentModel != null) ? parentModel.GetInstanceItemTextureBg(this.InstanceId) : null) ?? "";
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			base.SetExtendToggleTextureTransitionByPath(resourcePath, base.GetUiExtendToggleTextureTransition(5), EToggleTransitionState.ETT_UnCheckedUnHover);
		}

		// Token: 0x0603B638 RID: 243256 RVA: 0x00F0B8BC File Offset: 0x00F09ABC
		private void UpdateRedDot()
		{
			InstanceDungeonViewModelBase parentModel = this.ParentModel;
			bool uiactive = parentModel != null && parentModel.CheckInstanceItemHasRedDot(this.InstanceId);
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603B639 RID: 243257 RVA: 0x00F0B8F4 File Offset: 0x00F09AF4
		public void BindClickCallback([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<int, UUIExtendToggle, InstanceDetectionDynamicData> onClickCallback)
		{
			this.OnClickCallback = onClickCallback;
		}

		// Token: 0x0603B63A RID: 243258 RVA: 0x00F0B8FD File Offset: 0x00F09AFD
		[NullableContext(1)]
		public void BindCanExecuteChange(Func<int, bool> canExecuteChange)
		{
			this.InstanceCanExecuteChange = canExecuteChange;
		}

		// Token: 0x0603B63B RID: 243259 RVA: 0x00F0B906 File Offset: 0x00F09B06
		private bool CanExecuteChange()
		{
			return this.InstanceCanExecuteChange == null || this.InstanceCanExecuteChange(this.InstanceId);
		}

		// Token: 0x0603B63C RID: 243260 RVA: 0x00F0B923 File Offset: 0x00F09B23
		private void OnClickExtendToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.OnClickCallback != null)
			{
				this.OnClickCallback(this.InstanceId, this.ExtendToggle, null);
			}
		}

		// Token: 0x04021797 RID: 137111
		public UUIExtendToggle ExtendToggle;

		// Token: 0x04021798 RID: 137112
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Action<int, UUIExtendToggle, InstanceDetectionDynamicData> OnClickCallback;

		// Token: 0x04021799 RID: 137113
		private Func<int, bool> InstanceCanExecuteChange;

		// Token: 0x0402179A RID: 137114
		private int InstanceId;

		// Token: 0x0402179B RID: 137115
		private InstanceDungeonViewModelBase ParentModel;
	}
}
