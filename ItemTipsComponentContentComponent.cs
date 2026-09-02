using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200197E RID: 6526
[NullableContext(1)]
[Nullable(0)]
public class ItemTipsComponentContentComponent : UiPanelBase
{
	// Token: 0x0600BB99 RID: 48025 RVA: 0x0031D32C File Offset: 0x0031B52C
	[NullableContext(2)]
	public TipsBaseSubComponent GetComponentByType(EItemTipsType type)
	{
		if (!this.TipsSubComponentMap.ContainsKey(type))
		{
			Type type2;
			if (!this.TypeComponentRelationMap.TryGetValue(type, out type2))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[ItemTips] 常规Tips组件未注册,请检查类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			UUIItem item = base.GetItem(4);
			TipsBaseSubComponent value = (TipsBaseSubComponent)Activator.CreateInstance(type2, new object[]
			{
				item
			});
			this.TipsSubComponentMap.Add(type, value);
		}
		TipsBaseSubComponent result;
		if (this.TipsSubComponentMap.TryGetValue(type, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600BB9A RID: 48026 RVA: 0x0031D3C5 File Offset: 0x0031B5C5
	public void RefreshTipsComponentByType(ItemTipsData data)
	{
		this.GetComponentByType(data.ItemType).Refresh(data);
		this.GetComponentByType(data.ItemType).SetVisible(true);
	}

	// Token: 0x0600BB9B RID: 48027 RVA: 0x0031D3EC File Offset: 0x0031B5EC
	public void SetTipsComponentVisibleByType(EItemTipsType type, bool isShow)
	{
		TipsBaseSubComponent tipsBaseSubComponent;
		if (this.TipsSubComponentMap.TryGetValue(type, out tipsBaseSubComponent))
		{
			tipsBaseSubComponent.SetVisible(isShow);
		}
	}

	// Token: 0x0600BB9C RID: 48028 RVA: 0x0031D410 File Offset: 0x0031B610
	public void SetTipsComponentLockButton(bool isShow)
	{
		if (this.ItemType == null)
		{
			return;
		}
		this.GetComponentByType(this.ItemType.Value).SetLockButtonShow(isShow);
	}

	// Token: 0x0600BB9D RID: 48029 RVA: 0x0031D437 File Offset: 0x0031B637
	public void SetTipsNumShow(bool isShow)
	{
		if (this.ItemType == null)
		{
			return;
		}
		this.GetComponentByType(this.ItemType.Value).SetPanelNumVisible(isShow);
	}

	// Token: 0x0600BB9E RID: 48030 RVA: 0x0031D45E File Offset: 0x0031B65E
	public ESkipName GetTipsPreviewType()
	{
		return this.PreviewType;
	}

	// Token: 0x0600BB9F RID: 48031 RVA: 0x0031D466 File Offset: 0x0031B666
	public int GetTipsItemConfigId()
	{
		return this.ItemConfigId;
	}

	// Token: 0x0600BBA0 RID: 48032 RVA: 0x0031D470 File Offset: 0x0031B670
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickPreviewBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BBA1 RID: 48033 RVA: 0x0031D600 File Offset: 0x0031B800
	protected override void OnStart()
	{
		base.GetTexture(1).SetUIActive(false);
		base.GetButton(8).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600BBA2 RID: 48034 RVA: 0x0031D634 File Offset: 0x0031B834
	protected override void OnBeforeDestroy()
	{
		foreach (KeyValuePair<EItemTipsType, TipsBaseSubComponent> keyValuePair in this.TipsSubComponentMap)
		{
			keyValuePair.Value.Destroy(null);
		}
		this.TipsSubComponentMap.Clear();
		if (this.ButtonQuestFunction != null)
		{
			this.ButtonQuestFunction = null;
		}
	}

	// Token: 0x0600BBA3 RID: 48035 RVA: 0x0031D6A8 File Offset: 0x0031B8A8
	public void Refresh(ItemTipsData data)
	{
		if (this.ItemType != null)
		{
			this.SetTipsComponentVisibleByType(this.ItemType.Value, false);
		}
		this.ItemType = new EItemTipsType?(data.ItemType);
		this.ItemConfigId = data.ConfigId;
		this.PreviewType = data.PreviewType;
		this.RefreshBase(data);
		this.RefreshTipsComponentByType(data);
		this.SetActive(true);
	}

	// Token: 0x0600BBA4 RID: 48036 RVA: 0x0031D712 File Offset: 0x0031B912
	private void RefreshBase(ItemTipsData data)
	{
		this.RefreshBaseName(data);
		this.RefreshBaseQuality(data);
		this.RefreshBaseIcon(data);
		this.RefreshPreviewButton(data);
		this.SetDebugText(data.ConfigId);
	}

	// Token: 0x0600BBA5 RID: 48037 RVA: 0x0031D73C File Offset: 0x0031B93C
	private void RefreshBaseName(ItemTipsData data)
	{
		UUIText text = base.GetText(0);
		if (data.IsQualityByType)
		{
			text.SetUIActive(false);
			return;
		}
		QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(data.QualityId);
		if (qualityConfig != null)
		{
			FColor color = FColor.FromHex(qualityConfig.Value.DropColor);
			base.GetText(0).SetColor(color);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Title, Array.Empty<object>());
		}
	}

	// Token: 0x0600BBA6 RID: 48038 RVA: 0x0031D7B4 File Offset: 0x0031B9B4
	private void RefreshBaseQuality(ItemTipsData data)
	{
		UUIItem item = base.GetItem(7);
		if (data.IsQualityByType)
		{
			item.SetUIActive(false);
			return;
		}
		FColor color = FColor.FromHex(ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(data.QualityId).Value.ItemTipsEffectColor);
		item.SetColor(color);
		item.SetUIActive(true);
	}

	// Token: 0x0600BBA7 RID: 48039 RVA: 0x0031D810 File Offset: 0x0031BA10
	private void RefreshBaseIcon(ItemTipsData data)
	{
		base.GetTexture(2).SetUIActive(false);
		base.GetTexture(6).SetUIActive(false);
		UUITexture texture = base.GetTexture(2);
		if (data.IsShowIconBig())
		{
			texture = base.GetTexture(6);
		}
		if (data.IsIconByType)
		{
			texture.SetUIActive(false);
			return;
		}
		texture.SetUIActive(true);
		base.SetItemIcon(texture, data.ConfigId, null, null);
	}

	// Token: 0x0600BBA8 RID: 48040 RVA: 0x0031D880 File Offset: 0x0031BA80
	private void RefreshPreviewButton(ItemTipsData data)
	{
		base.GetButton(8).RootUIComp.Get().SetUIActive(data.PreviewType != ESkipName.NoSkip && data.ShowPreview);
	}

	// Token: 0x0600BBA9 RID: 48041 RVA: 0x0031D8B8 File Offset: 0x0031BAB8
	private void SetDebugText(int debugId)
	{
		UUIText text = base.GetText(5);
		if (!GlobalData.IsPlayInEditor)
		{
			text.SetUIActive(false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, "CommonTipsDebugItemId", new <>z__ReadOnlySingleElementList<object>(debugId));
		text.SetUIActive(true);
	}

	// Token: 0x0600BBAA RID: 48042 RVA: 0x0031D8FE File Offset: 0x0031BAFE
	private void OnClickPreviewBtn()
	{
		SkipTaskManager.Run(this.PreviewType, new object[]
		{
			this.ItemConfigId
		});
	}

	// Token: 0x0600BBAB RID: 48043 RVA: 0x0031D920 File Offset: 0x0031BB20
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		TipsBaseSubComponent tipsBaseSubComponent;
		if (configParams[0] == "DangoPlugin" && this.TipsSubComponentMap.TryGetValue(EItemTipsType.AbyssDango, out tipsBaseSubComponent))
		{
			return tipsBaseSubComponent.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		return null;
	}

	// Token: 0x040058A0 RID: 22688
	public EItemTipsType? ItemType;

	// Token: 0x040058A1 RID: 22689
	[Nullable(2)]
	private Action ButtonQuestFunction;

	// Token: 0x040058A2 RID: 22690
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly Dictionary<EItemTipsType, TipsBaseSubComponent> TipsSubComponentMap = new Dictionary<EItemTipsType, TipsBaseSubComponent>();

	// Token: 0x040058A3 RID: 22691
	private ESkipName PreviewType = ESkipName.NoSkip;

	// Token: 0x040058A4 RID: 22692
	private int ItemConfigId;

	// Token: 0x040058A5 RID: 22693
	private readonly Dictionary<EItemTipsType, Type> TypeComponentRelationMap = new Dictionary<EItemTipsType, Type>
	{
		{
			EItemTipsType.Normal,
			typeof(TipsMaterialComponent)
		},
		{
			EItemTipsType.Weapon,
			typeof(TipsWeaponComponent)
		},
		{
			EItemTipsType.Vision,
			typeof(TipsVisionComponent)
		},
		{
			EItemTipsType.Character,
			typeof(ItemTipsCharacterComponent)
		},
		{
			EItemTipsType.AbyssDango,
			typeof(ItemTipsAbyssDangoComponent)
		},
		{
			EItemTipsType.RoleSkin,
			typeof(TipsMaterialComponent)
		}
	};
}
