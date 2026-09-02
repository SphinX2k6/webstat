using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001019 RID: 4121
[NullableContext(1)]
[Nullable(0)]
public class DrinksMenuFlavorItem : GridProxyAbstract<int>
{
	// Token: 0x06006B30 RID: 27440 RVA: 0x001C0A74 File Offset: 0x001BEC74
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickedReduce))
		};
	}

	// Token: 0x06006B31 RID: 27441 RVA: 0x001C0B4C File Offset: 0x001BED4C
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksMenuFlavorItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksMenuFlavorItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B32 RID: 27442 RVA: 0x001C0B8F File Offset: 0x001BED8F
	protected override void OnStart()
	{
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		base.GetExtendToggle(0).OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnClickedToggle));
	}

	// Token: 0x06006B33 RID: 27443 RVA: 0x001C0BCC File Offset: 0x001BEDCC
	private void OnClickedReduce()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		base.GetButton(5).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06006B34 RID: 27444 RVA: 0x001C0C04 File Offset: 0x001BEE04
	private void OnClickedToggle(EToggleState _)
	{
		if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_UnDetermined)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Drinks_ConfirmBox_hit", Array.Empty<object>());
		}
	}

	// Token: 0x06006B35 RID: 27445 RVA: 0x001C0C29 File Offset: 0x001BEE29
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOnCb != null && this.Id != 0)
		{
			this.SetSelected(this.IsSelectOnCb(this.Id), false);
		}
	}

	// Token: 0x06006B36 RID: 27446 RVA: 0x001C0C54 File Offset: 0x001BEE54
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.Id = data;
		int curStep = (int)ModelBase<DrinksModel>.Instance.GetCurStep();
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (curStep == 2)
		{
			if (this.IsEnableCb != null)
			{
				if (!this.IsEnableCb(data))
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				}
				else if (this.IsSelectOnCb != null)
				{
					this.SetSelected(this.IsSelectOnCb(data), false);
				}
			}
			extendToggle.bLockStateOnSelect = false;
			List<ITasteInfo> list = new List<ITasteInfo>();
			DrinksBatching? batching = ConfigBase<DrinksConfig>.Instance.GetBatching(data);
			foreach (KeyValuePair<int, int> keyValuePair in batching.Value.Flavor())
			{
				TasteInfo item = new TasteInfo
				{
					Type = (EDrinksFlavorType)keyValuePair.Key,
					Key = "+{0}",
					Value = new string[]
					{
						keyValuePair.Value.ToString()
					}
				};
				list.Add(item);
			}
			this.TasteItem1.Refresh((list.Count > 0) ? list[0] : null);
			this.TasteItem2.Refresh((list.Count > 1) ? list[1] : null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(batching.Value.Name);
			}
			base.SetTextureByPath(batching.Value.Icon, base.GetTexture(1), null, null);
			return;
		}
		if (this.IsSelectOnCb != null)
		{
			this.SetSelected(this.IsSelectOnCb(data), false);
		}
		extendToggle.SetSelfInteractive(true);
		extendToggle.bLockStateOnSelect = true;
		DrinksDrinkBase? drinkBase = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(data);
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.ShowTextNew(drinkBase.Value.DrinkName);
		}
		base.SetTextureByPath(drinkBase.Value.DrinkIcon, base.GetTexture(1), null, null);
		List<ITasteInfo> flavorRange = this.GetFlavorRange(data);
		this.TasteItem1.Refresh((flavorRange.Count > 0) ? flavorRange[0] : null);
		this.TasteItem2.Refresh((flavorRange.Count > 1) ? flavorRange[1] : null);
	}

	// Token: 0x06006B37 RID: 27447 RVA: 0x001C0EC0 File Offset: 0x001BF0C0
	private List<ITasteInfo> GetFlavorRange(int configId)
	{
		DrinksDrinkBase? drinkBase = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(configId);
		Dictionary<int, int[]> drinksFlavorRange = ModelBase<DrinksModel>.Instance.GetDrinksFlavorRange(drinkBase.Value.DrinkId);
		List<ITasteInfo> list = new List<ITasteInfo>();
		foreach (KeyValuePair<int, int[]> keyValuePair in drinksFlavorRange)
		{
			int key = keyValuePair.Key;
			int[] value = keyValuePair.Value;
			int num = value[0];
			int num2 = value[1];
			TasteInfo item = new TasteInfo
			{
				Type = (EDrinksFlavorType)key,
				Key = "{0}~{1}",
				Value = new string[]
				{
					num.ToString(),
					num2.ToString()
				}
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06006B38 RID: 27448 RVA: 0x001C0F98 File Offset: 0x001BF198
	private void SetSelected(bool bSelectOn, bool bFireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		base.GetButton(5).RootUIComp.Get().SetUIActive(bSelectOn && curStep == EDrinksPlayStep.Batching);
	}

	// Token: 0x06006B39 RID: 27449 RVA: 0x001C0FEC File Offset: 0x001BF1EC
	private void OnToggleStateChange(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		base.GetButton(5).RootUIComp.Get().SetUIActive(flag);
		if (this.OnToggleStateChangeFunction != null)
		{
			this.OnToggleStateChangeFunction(base.GetExtendToggle(0), base.GetButton(5), this.Id, flag);
		}
	}

	// Token: 0x040032F0 RID: 13040
	private const string TXT_FLAVOR_DRINKS = "{0}~{1}";

	// Token: 0x040032F1 RID: 13041
	private const string TXT_FLAVOR_BATCHING = "+{0}";

	// Token: 0x040032F2 RID: 13042
	protected DrinksMenuFlavorTasteItem TasteItem1;

	// Token: 0x040032F3 RID: 13043
	protected DrinksMenuFlavorTasteItem TasteItem2;

	// Token: 0x040032F4 RID: 13044
	public int Id;

	// Token: 0x040032F5 RID: 13045
	[Nullable(2)]
	public Func<int, bool> IsSelectOnCb;

	// Token: 0x040032F6 RID: 13046
	[Nullable(2)]
	public Func<int, bool> IsEnableCb;

	// Token: 0x040032F7 RID: 13047
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<UUIExtendToggle, UUIButtonComponent, int, bool> OnToggleStateChangeFunction;

	// Token: 0x020073FC RID: 29692
	[NullableContext(0)]
	private static class EDefine
	{
		// Token: 0x040281DF RID: 164319
		public const int Toggle = 0;

		// Token: 0x040281E0 RID: 164320
		public const int Icon = 1;

		// Token: 0x040281E1 RID: 164321
		public const int Name = 2;

		// Token: 0x040281E2 RID: 164322
		public const int PanelTasteList = 3;

		// Token: 0x040281E3 RID: 164323
		public const int TasteItem1 = 4;

		// Token: 0x040281E4 RID: 164324
		public const int BtnReduce = 5;

		// Token: 0x040281E5 RID: 164325
		public const int TasteItem2 = 6;
	}
}
