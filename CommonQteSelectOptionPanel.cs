using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002625 RID: 9765
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteSelectOptionPanel : CommonQteItemBase<CommonQteSelectOptionContext>
{
	// Token: 0x0601336D RID: 78701 RVA: 0x005560B8 File Offset: 0x005542B8
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			return;
		}
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
	}

	// Token: 0x0601336E RID: 78702 RVA: 0x00556309 File Offset: 0x00554509
	public override void SetPreloadQte(int qteId)
	{
		this.PreloadQteId = qteId;
	}

	// Token: 0x0601336F RID: 78703 RVA: 0x00556314 File Offset: 0x00554514
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteSelectOptionPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteSelectOptionPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013370 RID: 78704 RVA: 0x00556358 File Offset: 0x00554558
	protected override void OnStart()
	{
		base.OnStart();
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.ProgressBar = base.GetSlider(5);
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		else
		{
			this.ProgressBar = base.GetSlider(11);
			this.GamepadProgressBar = base.GetSlider(13);
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(12);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			base.SetAttachRootItem(base.GetItem(16));
		}
		this.InitOptionItemOffset();
		this.RefreshOnInputControllerChange();
		base.SetUiActive(false);
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x06013371 RID: 78705 RVA: 0x0055641C File Offset: 0x0055461C
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem in this.OptionItemList)
		{
			commonQteSelectOptionItem.Destroy(null);
		}
		this.OptionItemList.Clear();
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem2 in this.GamepadOptionItemList)
		{
			commonQteSelectOptionItem2.Destroy(null);
		}
		this.GamepadOptionItemList.Clear();
	}

	// Token: 0x06013372 RID: 78706 RVA: 0x005564E8 File Offset: 0x005546E8
	private void OnInputControllerChange(EInputControllerType _1, EInputControllerType _2)
	{
		this.RefreshOnInputControllerChange();
	}

	// Token: 0x06013373 RID: 78707 RVA: 0x005564F0 File Offset: 0x005546F0
	protected void RefreshOnInputControllerChange()
	{
		if (this.GamepadOptionItemList.Count == 0)
		{
			return;
		}
		bool flag = Singleton<Info>.Instance.IsInGamepad();
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(14);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 != null)
		{
			item3.SetUIActive(flag);
		}
		UUIItem item4 = base.GetItem(15);
		if (item4 != null)
		{
			item4.SetUIActive(flag);
		}
		CommonQteSelectOptionContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && !commonQteContext.IsPermanent)
		{
			UUIItem item5 = base.GetItem(10);
			if (item5 != null)
			{
				item5.SetUIActive(!flag);
			}
			UUIItem item6 = base.GetItem(12);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(flag);
			return;
		}
		else
		{
			UUIItem item7 = base.GetItem(10);
			if (item7 != null)
			{
				item7.SetUIActive(false);
			}
			UUIItem item8 = base.GetItem(12);
			if (item8 == null)
			{
				return;
			}
			item8.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06013374 RID: 78708 RVA: 0x005565D0 File Offset: 0x005547D0
	private void InitOptionItemOffset()
	{
		switch (this.OptionItemList.Count)
		{
		case 2:
			this.OptionItemList[0].SetAnchorOffsetX(112f);
			return;
		case 3:
			this.OptionItemList[1].SetAnchorOffsetX(112f);
			return;
		case 4:
			this.OptionItemList[1].SetAnchorOffsetX(112f);
			this.OptionItemList[2].SetAnchorOffsetX(112f);
			return;
		default:
			return;
		}
	}

	// Token: 0x06013375 RID: 78709 RVA: 0x00556658 File Offset: 0x00554858
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSelectOptionContext;
	}

	// Token: 0x06013376 RID: 78710 RVA: 0x00556664 File Offset: 0x00554864
	public override void SetQteContext(CommonQteContextBase context)
	{
		CommonQteSelectOptionContext commonQteSelectOptionContext = context as CommonQteSelectOptionContext;
		if (commonQteSelectOptionContext == null)
		{
			return;
		}
		this.QteHandle = context.HandleId;
		this.CommonQteContext = commonQteSelectOptionContext;
		if (!commonQteSelectOptionContext.IsPermanent)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				UUIItem item = base.GetItem(4);
				if (item != null)
				{
					item.SetUIActive(true);
				}
			}
			else
			{
				UUIItem item2 = base.GetItem(10);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				UUIItem item3 = base.GetItem(12);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
			}
		}
		if (commonQteSelectOptionContext.IsAttachToActor())
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				UUIItem item4 = base.GetItem(6);
				if (item4 != null)
				{
					item4.SetAnchorOffset(Vector2D.ZeroVector);
				}
			}
			else
			{
				UUIItem item5 = base.GetItem(14);
				if (item5 != null)
				{
					item5.SetAnchorOffset(Vector2D.ZeroVector);
				}
				UUIItem item6 = base.GetItem(15);
				if (item6 != null)
				{
					item6.SetAnchorOffset(Vector2D.ZeroVector);
				}
			}
		}
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem in this.OptionItemList)
		{
			commonQteSelectOptionItem.SetQteContext(context);
		}
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem2 in this.GamepadOptionItemList)
		{
			commonQteSelectOptionItem2.SetQteContext(context);
		}
		base.SetQteActive(context);
		this.PlayQteStart();
	}

	// Token: 0x06013377 RID: 78711 RVA: 0x005567D0 File Offset: 0x005549D0
	protected override void OnPlayQteStart()
	{
		this.IsQteStart = true;
		this.IsQteInteractive = true;
		base.SetUiActive(true);
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem in this.OptionItemList)
		{
			commonQteSelectOptionItem.PlayQteStart();
		}
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem2 in this.GamepadOptionItemList)
		{
			commonQteSelectOptionItem2.PlayQteStart();
		}
	}

	// Token: 0x06013378 RID: 78712 RVA: 0x00556874 File Offset: 0x00554A74
	protected override void OnHandleQteEnd()
	{
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem in new List<CommonQteSelectOptionItem>(this.OptionItemList))
		{
			commonQteSelectOptionItem.PlayQteEnd();
		}
		foreach (CommonQteSelectOptionItem commonQteSelectOptionItem2 in new List<CommonQteSelectOptionItem>(this.GamepadOptionItemList))
		{
			commonQteSelectOptionItem2.PlayQteEnd();
		}
	}

	// Token: 0x06013379 RID: 78713 RVA: 0x00556910 File Offset: 0x00554B10
	public void OnOptionItemPlayEnded(CommonQteSelectOptionItem optionItem)
	{
		int num = this.OptionItemList.IndexOf(optionItem);
		if (num != -1)
		{
			this.OptionItemList.RemoveAt(num);
		}
		else if (this.GamepadOptionItemList.Count > 0)
		{
			int num2 = this.GamepadOptionItemList.IndexOf(optionItem);
			if (num2 != -1)
			{
				this.GamepadOptionItemList.RemoveAt(num2);
			}
		}
		if (this.OptionItemList.Count == 0 && this.GamepadOptionItemList.Count == 0)
		{
			base.Destroy(null);
		}
	}

	// Token: 0x0601337A RID: 78714 RVA: 0x00556988 File Offset: 0x00554B88
	protected override void OnTickQteItem(float delta)
	{
		if (!this.CommonQteContext.IsPermanent)
		{
			CommonQteSelectOptionContext commonQteContext = this.CommonQteContext;
			float inValue = (commonQteContext != null) ? commonQteContext.GetRemainingTimeProgress() : 1f;
			UUISliderComponent progressBar = this.ProgressBar;
			if (progressBar != null)
			{
				progressBar.SetValue(inValue, true);
			}
			UUISliderComponent gamepadProgressBar = this.GamepadProgressBar;
			if (gamepadProgressBar == null)
			{
				return;
			}
			gamepadProgressBar.SetValue(inValue, true);
		}
	}

	// Token: 0x0601337B RID: 78715 RVA: 0x005569DE File Offset: 0x00554BDE
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x040095F4 RID: 38388
	private const int MAX_OPTION_NUM = 4;

	// Token: 0x040095F5 RID: 38389
	private const int OPTION_ITEM_OFFSET = 112;

	// Token: 0x040095F6 RID: 38390
	private int PreloadQteId;

	// Token: 0x040095F7 RID: 38391
	private readonly List<CommonQteSelectOptionItem> OptionItemList = new List<CommonQteSelectOptionItem>();

	// Token: 0x040095F8 RID: 38392
	private readonly List<CommonQteSelectOptionItem> GamepadOptionItemList = new List<CommonQteSelectOptionItem>();

	// Token: 0x040095F9 RID: 38393
	[Nullable(2)]
	private UUISliderComponent ProgressBar;

	// Token: 0x040095FA RID: 38394
	[Nullable(2)]
	private UUISliderComponent GamepadProgressBar;

	// Token: 0x020089C8 RID: 35272
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402E7AA RID: 190378
		DesktopOptionItem1,
		// Token: 0x0402E7AB RID: 190379
		DesktopOptionItem2,
		// Token: 0x0402E7AC RID: 190380
		DesktopOptionItem3,
		// Token: 0x0402E7AD RID: 190381
		DesktopOptionItem4,
		// Token: 0x0402E7AE RID: 190382
		DesktopOptionPanel,
		// Token: 0x0402E7AF RID: 190383
		GamepadOptionPanel,
		// Token: 0x0402E7B0 RID: 190384
		GamepadOptionItem1,
		// Token: 0x0402E7B1 RID: 190385
		GamepadOptionItem2,
		// Token: 0x0402E7B2 RID: 190386
		GamepadOptionItem3,
		// Token: 0x0402E7B3 RID: 190387
		GamepadOptionItem4,
		// Token: 0x0402E7B4 RID: 190388
		DesktopProgressPanel,
		// Token: 0x0402E7B5 RID: 190389
		DesktopProgressBar,
		// Token: 0x0402E7B6 RID: 190390
		GamepadProgressPanel,
		// Token: 0x0402E7B7 RID: 190391
		GamepadProgressBar,
		// Token: 0x0402E7B8 RID: 190392
		DesktopOffsetPanel,
		// Token: 0x0402E7B9 RID: 190393
		GamepadOffsetPanel,
		// Token: 0x0402E7BA RID: 190394
		AttachRootItem
	}

	// Token: 0x020089C9 RID: 35273
	[NullableContext(0)]
	private enum EMobileChildType
	{
		// Token: 0x0402E7BC RID: 190396
		OptionItem1,
		// Token: 0x0402E7BD RID: 190397
		OptionItem2,
		// Token: 0x0402E7BE RID: 190398
		OptionItem3,
		// Token: 0x0402E7BF RID: 190399
		OptionItem4,
		// Token: 0x0402E7C0 RID: 190400
		ProgressPanel,
		// Token: 0x0402E7C1 RID: 190401
		ProgressBar,
		// Token: 0x0402E7C2 RID: 190402
		OffsetPanel
	}
}
