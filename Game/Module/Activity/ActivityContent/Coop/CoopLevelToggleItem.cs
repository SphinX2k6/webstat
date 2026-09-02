using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x0200699D RID: 27037
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopLevelToggleItem : UiPanelBase
	{
		// Token: 0x06043119 RID: 274713 RVA: 0x01139D28 File Offset: 0x01137F28
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTogSelf))
			};
		}

		// Token: 0x0604311A RID: 274714 RVA: 0x01139E57 File Offset: 0x01138057
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnCoopLevelToggleClick, new Action<int>(this.HandleSelected));
		}

		// Token: 0x0604311B RID: 274715 RVA: 0x01139E92 File Offset: 0x01138092
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopLevelToggleClick, new Action<int>(this.HandleSelected));
		}

		// Token: 0x0604311C RID: 274716 RVA: 0x01139EB0 File Offset: 0x011380B0
		public void SetClickCallBack(Action<CoopLevelData> func)
		{
			this.OnClickTogCallBack = func;
		}

		// Token: 0x0604311D RID: 274717 RVA: 0x01139EB9 File Offset: 0x011380B9
		public void SetCanExecuteChangeFunc(Func<int, bool> func)
		{
			this.CanExecuteChangeFuncField = func;
		}

		// Token: 0x0604311E RID: 274718 RVA: 0x01139EC2 File Offset: 0x011380C2
		private void OnClickTogSelf(EToggleState _)
		{
			if (this.OnClickTogCallBack != null)
			{
				this.OnClickTogCallBack(this.Data);
			}
		}

		// Token: 0x0604311F RID: 274719 RVA: 0x01139EDD File Offset: 0x011380DD
		private bool CanExecuteChange()
		{
			return this.CanExecuteChangeFuncField != null && this.CanExecuteChangeFuncField(this.Data.Level);
		}

		// Token: 0x06043120 RID: 274720 RVA: 0x01139F00 File Offset: 0x01138100
		public void Refresh(CoopLevelData data)
		{
			this.Data = data;
			CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(data.LevelId);
			this.UpdateStatus(data.State);
			base.GetItem(6).SetUIActive(data.State == ECoopLevelStatus.Reward);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), (coopConfigById != null) ? coopConfigById.GetValueOrDefault().EventTitle : null, Array.Empty<object>());
		}

		// Token: 0x06043121 RID: 274721 RVA: 0x01139F78 File Offset: 0x01138178
		public void UpdateStatus(ECoopLevelStatus state)
		{
			base.GetItem(10).SetUIActive(false);
			switch (state)
			{
			case ECoopLevelStatus.Lock:
				base.GetItem(3).SetUIActive(true);
				base.GetItem(4).SetUIActive(false);
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(true);
				base.GetItem(9).SetUIActive(false);
				base.GetText(5).SetFontOutlineColor(FColor.FromHex("4836a0"));
				return;
			case ECoopLevelStatus.Doing:
				base.GetItem(3).SetUIActive(true);
				base.GetItem(4).SetUIActive(false);
				base.GetItem(7).SetUIActive(true);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(9).SetUIActive(false);
				base.GetItem(10).SetUIActive(this.Data.IsShowDoingNew);
				base.GetText(5).SetFontOutlineColor(FColor.FromHex("4836a0"));
				return;
			case ECoopLevelStatus.Reward:
				base.GetItem(3).SetUIActive(false);
				base.GetItem(4).SetUIActive(true);
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(9).SetUIActive(true);
				base.GetText(5).SetFontOutlineColor(FColor.FromHex("52402c"));
				return;
			case ECoopLevelStatus.Done:
				base.GetItem(3).SetUIActive(false);
				base.GetItem(4).SetUIActive(true);
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(9).SetUIActive(true);
				base.GetText(5).SetFontOutlineColor(FColor.FromHex("52402c"));
				return;
			default:
				return;
			}
		}

		// Token: 0x06043122 RID: 274722 RVA: 0x0113A125 File Offset: 0x01138325
		public void UnSelected()
		{
			this.SetToggleState(false);
		}

		// Token: 0x06043123 RID: 274723 RVA: 0x0113A12E File Offset: 0x0113832E
		private void HandleSelected(int id)
		{
			CoopLevelData data = this.Data;
			if (data == null || data.LevelId != id)
			{
				this.OnDeselected();
				return;
			}
			this.OnSelected();
			UiNavigationNewController instance = ControllerBase<UiNavigationNewController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetNavigationFocusForView(this.RootItem, true, true, false);
		}

		// Token: 0x06043124 RID: 274724 RVA: 0x0113A16D File Offset: 0x0113836D
		public void SetRightPanelShow(bool isShow)
		{
			base.GetItem(1).SetUIActive(isShow);
			base.GetItem(2).SetUIActive(isShow);
		}

		// Token: 0x06043125 RID: 274725 RVA: 0x0113A18C File Offset: 0x0113838C
		private void OnSelected()
		{
			if (this.Data.IsShowDoingNew)
			{
				ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.CoopRoleNewLevelRedDot) as ServerStorageSet;
				base.GetItem(10).SetUIActive(false);
				serverStorageSet.Add(this.Data.LevelId);
				CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(this.Data.LevelId);
				if (coopConfigById != null)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, coopConfigById.Value.ActivityId);
				}
			}
			this.SetToggleState(true);
		}

		// Token: 0x06043126 RID: 274726 RVA: 0x0113A21A File Offset: 0x0113841A
		private void OnDeselected()
		{
			this.SetToggleState(false);
		}

		// Token: 0x06043127 RID: 274727 RVA: 0x0113A224 File Offset: 0x01138424
		private void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x040255F5 RID: 153077
		[Nullable(2)]
		public CoopLevelData Data;

		// Token: 0x040255F6 RID: 153078
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<CoopLevelData> OnClickTogCallBack;

		// Token: 0x040255F7 RID: 153079
		[Nullable(2)]
		private Func<int, bool> CanExecuteChangeFuncField;
	}
}
