using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006554 RID: 25940
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenTabItem : UiPanelBase
	{
		// Token: 0x06040D1C RID: 265500 RVA: 0x0109F37A File Offset: 0x0109D57A
		public RealmBetweenTabItem(ActivityRealmBetweenData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040D1D RID: 265501 RVA: 0x0109F38C File Offset: 0x0109D58C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectOn))
			};
		}

		// Token: 0x06040D1E RID: 265502 RVA: 0x0109F44C File Offset: 0x0109D64C
		public UniTask Init(UUIItem actor)
		{
			RealmBetweenTabItem.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RealmBetweenTabItem.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06040D1F RID: 265503 RVA: 0x0109F497 File Offset: 0x0109D697
		protected override void OnStart()
		{
		}

		// Token: 0x06040D20 RID: 265504 RVA: 0x0109F499 File Offset: 0x0109D699
		public void BindSelectedCallBack(Action<RealmBetweenAreaData, int> callback)
		{
			this.SelectedCallBack = callback;
		}

		// Token: 0x06040D21 RID: 265505 RVA: 0x0109F4A2 File Offset: 0x0109D6A2
		public void BindIsSelectedOn(Func<RealmBetweenAreaData, int, bool> isSelectedOn)
		{
			this.IsSelectedOnFunc = isSelectedOn;
		}

		// Token: 0x06040D22 RID: 265506 RVA: 0x0109F4AC File Offset: 0x0109D6AC
		private void OnToggleSelectOn(EToggleState state)
		{
			if (this.Data != null)
			{
				this.ActivityBaseData.SaveFirstCheckRedDotState(ERealmBetweenSaveFlag.AreaNewUnlock, this.Data.AreaId);
				this.RefreshByData(this.Data, this.Index);
				Action<RealmBetweenAreaData, int> selectedCallBack = this.SelectedCallBack;
				if (selectedCallBack != null)
				{
					selectedCallBack(this.Data, this.Index);
				}
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06040D23 RID: 265507 RVA: 0x0109F518 File Offset: 0x0109D718
		public void Update(RealmBetweenAreaData data, int index)
		{
			this.RefreshByData(data, index);
			Func<RealmBetweenAreaData, int, bool> isSelectedOnFunc = this.IsSelectedOnFunc;
			bool bOn = isSelectedOnFunc != null && isSelectedOnFunc(data, index);
			this.SetSelected(bOn, false);
		}

		// Token: 0x06040D24 RID: 265508 RVA: 0x0109F54C File Offset: 0x0109D74C
		public void SetSelected(bool bOn, bool bFireEvent)
		{
			EToggleState state = bOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, bFireEvent, false, false);
		}

		// Token: 0x06040D25 RID: 265509 RVA: 0x0109F574 File Offset: 0x0109D774
		private void RefreshByData(RealmBetweenAreaData data, int index)
		{
			this.Data = data;
			this.Index = index;
			Area value = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
			bool uiactive = data.IsUnlock && this.ActivityBaseData.IsAreaTaskFinish(data.AreaId);
			bool flag = data.IsUnlock && this.ActivityBaseData.GetAreaRewardState(data.AreaId);
			bool areaNewUnlockState = this.ActivityBaseData.GetAreaNewUnlockState(data.AreaId);
			base.GetItem(2).SetUIActive(uiactive);
			base.GetItem(3).SetUIActive(!data.IsUnlock);
			base.GetItem(4).SetUIActive(flag && !areaNewUnlockState);
			base.GetItem(5).SetUIActive(areaNewUnlockState);
		}

		// Token: 0x06040D26 RID: 265510 RVA: 0x0109F657 File Offset: 0x0109D857
		public void MarkNewUnlockSeen()
		{
			if (this.Data != null)
			{
				this.ActivityBaseData.SaveFirstCheckRedDotState(ERealmBetweenSaveFlag.AreaNewUnlock, this.Data.AreaId);
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x040245EA RID: 148970
		[Nullable(2)]
		protected RealmBetweenAreaData Data;

		// Token: 0x040245EB RID: 148971
		protected int Index;

		// Token: 0x040245EC RID: 148972
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<RealmBetweenAreaData, int> SelectedCallBack;

		// Token: 0x040245ED RID: 148973
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<RealmBetweenAreaData, int, bool> IsSelectedOnFunc;

		// Token: 0x040245EE RID: 148974
		protected ActivityRealmBetweenData ActivityBaseData;
	}
}
