using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001820 RID: 6176
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineSlotItem : UiPanelBase, IGridProxy<VisionRefineSlotItemData>
{
	// Token: 0x0600AFE7 RID: 45031 RVA: 0x002EE3EF File Offset: 0x002EC5EF
	public VisionRefineSlotItem(Action<bool, int> callBack = null)
	{
		this.ClickCallBack = callBack;
	}

	// Token: 0x17000E55 RID: 3669
	// (get) Token: 0x0600AFE8 RID: 45032 RVA: 0x002EE3FE File Offset: 0x002EC5FE
	// (set) Token: 0x0600AFE9 RID: 45033 RVA: 0x002EE406 File Offset: 0x002EC606
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<VisionRefineSlotItemData>, VisionRefineSlotItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17000E56 RID: 3670
	// (get) Token: 0x0600AFEA RID: 45034 RVA: 0x002EE40F File Offset: 0x002EC60F
	// (set) Token: 0x0600AFEB RID: 45035 RVA: 0x002EE417 File Offset: 0x002EC617
	public int GridIndex { get; set; }

	// Token: 0x17000E57 RID: 3671
	// (get) Token: 0x0600AFEC RID: 45036 RVA: 0x002EE420 File Offset: 0x002EC620
	// (set) Token: 0x0600AFED RID: 45037 RVA: 0x002EE428 File Offset: 0x002EC628
	public int DisplayIndex { get; set; }

	// Token: 0x0600AFEE RID: 45038 RVA: 0x002EE431 File Offset: 0x002EC631
	[NullableContext(1)]
	public void Refresh(VisionRefineSlotItemData data, bool isSelected, int gridIndex)
	{
		if (data.ItemData == null)
		{
			this.RefreshEmpty();
			return;
		}
		this.RefreshByData(data.ItemData, data.IsConfirm, data.Cost);
	}

	// Token: 0x0600AFEF RID: 45039 RVA: 0x002EE45A File Offset: 0x002EC65A
	[NullableContext(1)]
	public UniTask RefreshAsync(VisionRefineSlotItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
		return UniTask.CompletedTask;
	}

	// Token: 0x0600AFF0 RID: 45040 RVA: 0x002EE46A File Offset: 0x002EC66A
	public void Clear()
	{
	}

	// Token: 0x0600AFF1 RID: 45041 RVA: 0x002EE46C File Offset: 0x002EC66C
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600AFF2 RID: 45042 RVA: 0x002EE46E File Offset: 0x002EC66E
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600AFF3 RID: 45043 RVA: 0x002EE470 File Offset: 0x002EC670
	[NullableContext(1)]
	[return: Nullable(2)]
	public object GetKey(VisionRefineSlotItemData data, int gridIndex)
	{
		return data;
	}

	// Token: 0x0600AFF4 RID: 45044 RVA: 0x002EE474 File Offset: 0x002EC674
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(0, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickAddButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickRemoveButton))
		};
	}

	// Token: 0x0600AFF5 RID: 45045 RVA: 0x002EE5EC File Offset: 0x002EC7EC
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineSlotItem.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineSlotItem.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AFF6 RID: 45046 RVA: 0x002EE630 File Offset: 0x002EC830
	protected override void OnStart()
	{
		bool enable = this.ClickCallBack != null;
		base.GetUiSpriteTransition(0).SetEnable(enable);
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600AFF7 RID: 45047 RVA: 0x002EE668 File Offset: 0x002EC868
	public void RefreshEmpty()
	{
		base.GetItem(1).SetUIActive(true);
		base.GetItem(7).SetUIActive(false);
		base.GetTexture(2).SetUIActive(false);
		base.GetSprite(3).SetUIActive(false);
		base.GetButton(5).RootUIComp.Get().SetUIActive(false);
		this.ElementItemUp.SetUiActive(false);
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(11);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(false);
	}

	// Token: 0x0600AFF8 RID: 45048 RVA: 0x002EE70C File Offset: 0x002EC90C
	[NullableContext(1)]
	public void RefreshByData(PhantomItemData itemData, bool isConfirm, int cost)
	{
		UUITexture icon = base.GetTexture(2);
		UUISprite qualitySprite = base.GetSprite(3);
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(itemData.GetQuality());
		this.SetSpriteByPath(phantomQualityBgSprite, qualitySprite, false, null, delegate(bool _)
		{
			qualitySprite.SetUIActive(true);
		});
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(itemData.GetUniqueId());
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(phantomBattleData.GetConfigId(true));
		base.SetTextureByPath(itemConfigData.IconMiddle, icon, null, delegate(bool _)
		{
			icon.SetUIActive(true);
			this.GetItem(1).SetUIActive(false);
			this.GetButton(5).RootUIComp.Get().SetUIActive(!isConfirm);
			PhantomFetterGroup? fetterGroupConfig = itemData.GetFetterGroupConfig();
			if (fetterGroupConfig != null)
			{
				this.ElementItemUp.Update(fetterGroupConfig);
			}
			this.ElementItemUp.SetUiActive(fetterGroupConfig != null);
			if (this.OnIsShouldElementItemDownCallback != null && this.OnIsShouldElementItemDownCallback() && fetterGroupConfig != null)
			{
				this.GetItem(7).SetUIActive(false);
			}
			else
			{
				this.GetItem(7).SetUIActive(true);
				this.GetText(8).SetText(cost.ToString(), true);
			}
			if (this.OnGetMainPropItemIdCallback == null)
			{
				UUIItem item = this.GetItem(11);
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			else
			{
				int? num = this.OnGetMainPropItemIdCallback();
				if (num == null)
				{
					UUIItem item2 = this.GetItem(11);
					if (item2 != null)
					{
						item2.SetUIActive(false);
					}
				}
				else
				{
					PhantomItemData itemData2 = itemData;
					int? num2 = (itemData2 != null) ? new int?(itemData2.GetUniqueId()) : null;
					if (num2 != null)
					{
						PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(num2.Value);
						if (phantomDataBase != null)
						{
							UUIItem item3 = this.GetItem(11);
							if (item3 != null)
							{
								int? num3 = num;
								int phantomPropId = phantomDataBase.GetPhantomFirstMainProp().PhantomPropId;
								item3.SetUIActive(num3.GetValueOrDefault() == phantomPropId & num3 != null);
							}
						}
					}
				}
			}
			if (this.OnIsShouldElementItemDownCallback != null && this.OnIsShouldElementItemDownCallback())
			{
				UUIItem item4 = this.GetItem(9);
				if (item4 != null)
				{
					item4.SetUIActive(itemData.GetIsLock());
				}
				UUIItem item5 = this.GetItem(10);
				if (item5 == null)
				{
					return;
				}
				item5.SetUIActive(itemData.GetIsDeprecated());
				return;
			}
			else
			{
				UUIItem item6 = this.GetItem(9);
				if (item6 != null)
				{
					item6.SetUIActive(false);
				}
				UUIItem item7 = this.GetItem(10);
				if (item7 == null)
				{
					return;
				}
				item7.SetUIActive(false);
				return;
			}
		});
	}

	// Token: 0x0600AFF9 RID: 45049 RVA: 0x002EE7DF File Offset: 0x002EC9DF
	private void OnClickAddButton()
	{
		if (this.ClickCallBack != null)
		{
			this.ClickCallBack(true, this.GridIndex);
		}
	}

	// Token: 0x0600AFFA RID: 45050 RVA: 0x002EE7FB File Offset: 0x002EC9FB
	private void OnClickRemoveButton()
	{
		if (this.ClickCallBack != null)
		{
			this.ClickCallBack(false, this.GridIndex);
		}
	}

	// Token: 0x0600AFFB RID: 45051 RVA: 0x002EE817 File Offset: 0x002ECA17
	public void SetBtnInteractive(bool interActive)
	{
		UUIButtonComponent button = base.GetButton(4);
		button.SetSelectionState(EUISelectableSelectionState.Normal);
		button.SetSelfInteractive(interActive);
	}

	// Token: 0x0400535F RID: 21343
	private VisionFetterSuitItem ElementItemUp;

	// Token: 0x04005360 RID: 21344
	private readonly Action<bool, int> ClickCallBack;

	// Token: 0x04005361 RID: 21345
	public Func<int?> OnGetMainPropItemIdCallback;

	// Token: 0x04005362 RID: 21346
	public Func<bool> OnIsShouldElementItemDownCallback;

	// Token: 0x02007BA4 RID: 31652
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A42D RID: 173101
		ChooseTransition,
		// Token: 0x0402A42E RID: 173102
		EmptyItem,
		// Token: 0x0402A42F RID: 173103
		Icon,
		// Token: 0x0402A430 RID: 173104
		QualitySprite,
		// Token: 0x0402A431 RID: 173105
		AddVisionButton,
		// Token: 0x0402A432 RID: 173106
		RemoveButton,
		// Token: 0x0402A433 RID: 173107
		ElementItemUp,
		// Token: 0x0402A434 RID: 173108
		CostPanel,
		// Token: 0x0402A435 RID: 173109
		CostText,
		// Token: 0x0402A436 RID: 173110
		LockItem,
		// Token: 0x0402A437 RID: 173111
		MarkDeleteItem,
		// Token: 0x0402A438 RID: 173112
		WarningItem,
		// Token: 0x0402A439 RID: 173113
		ElementItemDown
	}
}
