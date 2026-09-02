using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200286D RID: 10349
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorHintView : UiTickViewBase
{
	// Token: 0x060147F9 RID: 83961 RVA: 0x005AFBAA File Offset: 0x005ADDAA
	public RoleFavorHintView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060147FA RID: 83962 RVA: 0x005AFBBE File Offset: 0x005ADDBE
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout))
		};
	}

	// Token: 0x060147FB RID: 83963 RVA: 0x005AFBF8 File Offset: 0x005ADDF8
	protected override void OnStart()
	{
		this.RoleFavorHintDataList = ((this.OpenParam as List<RoleFavorHintData>) ?? new List<RoleFavorHintData>());
		this.RoleFavorHintDataList = this.CombineData(this.RoleFavorHintDataList);
		UUILayoutBase verticalLayout = base.GetVerticalLayout(1);
		TLayoutRefresh<RoleFavorHintItem> refreshFunction;
		if ((refreshFunction = RoleFavorHintView.<>O.<0>__InitFavorExpItem) == null)
		{
			refreshFunction = (RoleFavorHintView.<>O.<0>__InitFavorExpItem = new TLayoutRefresh<RoleFavorHintItem>(FavorExpItemFactory.InitFavorExpItem));
		}
		this.VerticalLayout = new GenericLayoutNew<RoleFavorHintItem>(verticalLayout, refreshFunction, null);
		this.VerticalLayout.RebuildLayoutByDataNew<RoleFavorHintData>(this.RoleFavorHintDataList, null);
		this.FinishSequenceItemCount = this.RoleFavorHintDataList.Count;
		foreach (KeyValuePair<object, RoleFavorHintItem> keyValuePair in this.VerticalLayout.GetLayoutItemMap())
		{
			keyValuePair.Value.SetSequenceFinishCallBack(new TOnSequenceFinishCallBack(this.OnSequenceFinishCallBack));
		}
	}

	// Token: 0x060147FC RID: 83964 RVA: 0x005AFCE8 File Offset: 0x005ADEE8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<RoleFavorHintData>>(EEventName.UpdateRoleFavorHintView, new Action<IReadOnlyList<RoleFavorHintData>>(this.UpdateRoleFavorHintView));
	}

	// Token: 0x060147FD RID: 83965 RVA: 0x005AFD06 File Offset: 0x005ADF06
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleFavorHintView, new Action<IReadOnlyList<RoleFavorHintData>>(this.UpdateRoleFavorHintView));
	}

	// Token: 0x060147FE RID: 83966 RVA: 0x005AFD24 File Offset: 0x005ADF24
	private void UpdateRoleFavorHintView(IReadOnlyList<RoleFavorHintData> roleFavorHintData)
	{
		List<RoleFavorHintData> list = new List<RoleFavorHintData>(roleFavorHintData.Count);
		for (int i = 0; i < roleFavorHintData.Count; i++)
		{
			list.Add(roleFavorHintData[i]);
		}
		List<RoleFavorHintData> list2 = this.CombineData(list);
		int count = list2.Count;
		for (int j = 0; j < count; j++)
		{
			RoleFavorHintData item = list2[j];
			this.RoleFavorHintDataList.Add(item);
		}
		this.VerticalLayout.ClearChildren();
		this.VerticalLayout.RebuildLayoutByDataNew<RoleFavorHintData>(this.RoleFavorHintDataList, null);
		this.FinishSequenceItemCount = this.RoleFavorHintDataList.Count;
		foreach (KeyValuePair<object, RoleFavorHintItem> keyValuePair in this.VerticalLayout.GetLayoutItemMap())
		{
			keyValuePair.Value.SetSequenceFinishCallBack(new TOnSequenceFinishCallBack(this.OnSequenceFinishCallBack));
		}
	}

	// Token: 0x060147FF RID: 83967 RVA: 0x005AFE28 File Offset: 0x005AE028
	private List<RoleFavorHintData> CombineData(List<RoleFavorHintData> roleFavorHintData)
	{
		if (ModelBase<EditFormationModel>.Instance.GetCurrentFormationData == null)
		{
			return roleFavorHintData;
		}
		int[] getRoleIdList = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData.GetRoleIdList;
		if (getRoleIdList == null || getRoleIdList.Length == 0)
		{
			return roleFavorHintData;
		}
		int num = getRoleIdList.Length;
		HashSet<int> hashSet = new HashSet<int>();
		int num2 = 0;
		bool flag = true;
		RoleFavorHintData roleFavorHintData2 = null;
		for (int i = 0; i < num; i++)
		{
			int num3 = getRoleIdList[i];
			int count = roleFavorHintData.Count;
			bool flag2 = false;
			for (int j = 0; j < count; j++)
			{
				RoleFavorHintData roleFavorHintData3 = roleFavorHintData[j];
				if (roleFavorHintData3.RoleConfig.Value.Id == num3)
				{
					if (num2 == 0)
					{
						num2 = roleFavorHintData3.Exp;
						flag2 = true;
						roleFavorHintData2 = roleFavorHintData3;
					}
					else
					{
						flag2 = (roleFavorHintData3.Exp == num2);
					}
					hashSet.Add(j);
					break;
				}
			}
			if (!flag2)
			{
				flag = false;
			}
		}
		if (flag && roleFavorHintData2 != null)
		{
			int count2 = roleFavorHintData.Count;
			List<RoleFavorHintData> list = new List<RoleFavorHintData>();
			list.Add(roleFavorHintData2);
			for (int k = 0; k < count2; k++)
			{
				if (!hashSet.Contains(k))
				{
					RoleFavorHintData item = roleFavorHintData[k];
					list.Add(item);
				}
			}
			return list;
		}
		return roleFavorHintData;
	}

	// Token: 0x06014800 RID: 83968 RVA: 0x005AFF4A File Offset: 0x005AE14A
	protected override void OnBeforeDestroy()
	{
		this.RoleFavorHintDataList.Clear();
		if (this.VerticalLayout != null)
		{
			this.VerticalLayout.ClearChildren();
			this.VerticalLayout = null;
		}
		this.FinishSequenceItemCount = 0;
	}

	// Token: 0x06014801 RID: 83969 RVA: 0x005AFF78 File Offset: 0x005AE178
	private void OnSequenceFinishCallBack()
	{
		this.FinishSequenceItemCount--;
		if (this.FinishSequenceItemCount == 0)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleFavorHintView, null);
		}
	}

	// Token: 0x04009E72 RID: 40562
	private List<RoleFavorHintData> RoleFavorHintDataList = new List<RoleFavorHintData>();

	// Token: 0x04009E73 RID: 40563
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<RoleFavorHintItem> VerticalLayout;

	// Token: 0x04009E74 RID: 40564
	private int FinishSequenceItemCount;

	// Token: 0x02008BD5 RID: 35797
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402F1D5 RID: 192981
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static TLayoutRefresh<RoleFavorHintItem> <0>__InitFavorExpItem;
	}
}
