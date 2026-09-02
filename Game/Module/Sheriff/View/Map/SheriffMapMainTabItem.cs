using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Map
{
	// Token: 0x02004FDD RID: 20445
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffMapMainTabItem : GridProxyAbstract<ISheriffMainTabItemData>
	{
		// Token: 0x06034B67 RID: 215911 RVA: 0x00D384E8 File Offset: 0x00D366E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggleSpriteTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B68 RID: 215912 RVA: 0x00D385B0 File Offset: 0x00D367B0
		private void OnClickItem(EToggleState state)
		{
			if (state == EToggleState.ETT_UnChecked)
			{
				return;
			}
			IScrollViewDelegate<IGridProxy<ISheriffMainTabItemData>, ISheriffMainTabItemData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate != null)
			{
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
			}
			if (this.Data == null)
			{
				return;
			}
			Action<ISheriffMainTabItemData> selectCallBack = this.SelectCallBack;
			if (selectCallBack == null)
			{
				return;
			}
			selectCallBack(this.Data);
		}

		// Token: 0x06034B69 RID: 215913 RVA: 0x00D385FE File Offset: 0x00D367FE
		protected override void OnStart()
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			base.GetExtendToggle(0).bLockStateOnSelect = true;
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x06034B6A RID: 215914 RVA: 0x00D3863A File Offset: 0x00D3683A
		private void OnUndeterminedClicked()
		{
			this.OpenConditionView();
		}

		// Token: 0x06034B6B RID: 215915 RVA: 0x00D38644 File Offset: 0x00D36844
		public override void Refresh(ISheriffMainTabItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.TabTxt, Array.Empty<object>());
			string tabIcon = data.TabIcon;
			UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(2);
			EToggleTransitionState[] array = new EToggleTransitionState[6];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.7723512959E7AC842AB4353C8D2156604031425482D367DAB73DB105164F34FA).FieldHandle);
			base.SetExtendToggleSpriteTransitionByStateList(tabIcon, uiExtendToggleSpriteTransition, array);
			if (data.IsLock.GetValueOrDefault())
			{
				base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
			}
		}

		// Token: 0x06034B6C RID: 215916 RVA: 0x00D386B9 File Offset: 0x00D368B9
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06034B6D RID: 215917 RVA: 0x00D386CB File Offset: 0x00D368CB
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06034B6E RID: 215918 RVA: 0x00D386DD File Offset: 0x00D368DD
		public override object GetKey(ISheriffMainTabItemData data, int displayIndex)
		{
			return data.TabType;
		}

		// Token: 0x06034B6F RID: 215919 RVA: 0x00D386EC File Offset: 0x00D368EC
		public void OpenConditionView()
		{
			FunctionCondition? config = ConfigFunctionConditionByFunctionId.GetConfig((int)this.Data.FunctionType, true);
			if (config == null)
			{
				return;
			}
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			int[] groupConditionIds = ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(config.Value.OpenConditionId);
			if (groupConditionIds == null)
			{
				return;
			}
			foreach (int conditionId in groupConditionIds)
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
				if (conditionConfig != null)
				{
					int accessType = -1;
					if (!string.IsNullOrEmpty(conditionConfig.Value.Description))
					{
						if (conditionConfig.Value.AccessId != 0)
						{
							AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId);
							accessType = ((configById != null) ? configById.GetValueOrDefault().SkipName : -1);
						}
						ActivityConditionData item = new ActivityConditionData
						{
							ConditionId = conditionId,
							ConditionTextId = conditionConfig.Value.Description,
							IsFinished = false,
							AccessId = conditionConfig.Value.AccessId,
							AccessType = accessType
						};
						list.Add(item);
					}
				}
			}
			ConditionGroupData param = new ConditionGroupData(config.Value.OpenConditionId, list, "", false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}

		// Token: 0x0401E613 RID: 124435
		[Nullable(2)]
		private ISheriffMainTabItemData Data;

		// Token: 0x0401E614 RID: 124436
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ISheriffMainTabItemData> SelectCallBack;

		// Token: 0x0200AFB0 RID: 44976
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04036843 RID: 223299
			public const int Toggle = 0;

			// Token: 0x04036844 RID: 223300
			public const int Text = 1;

			// Token: 0x04036845 RID: 223301
			public const int Icon = 2;
		}
	}
}
