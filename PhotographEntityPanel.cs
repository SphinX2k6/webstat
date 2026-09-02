using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020025D8 RID: 9688
[NullableContext(1)]
[Nullable(0)]
public class PhotographEntityPanel : UiPanelBase
{
	// Token: 0x06012F0B RID: 77579 RVA: 0x0053CD40 File Offset: 0x0053AF40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06012F0C RID: 77580 RVA: 0x0053CDDC File Offset: 0x0053AFDC
	protected override void OnStart()
	{
		this.InfoLayout = new GenericLayoutNew<EntityInfoItem>(base.GetVerticalLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<EntityInfoItem>(this.CreateInfoItem), null);
		this.FatherIcon = base.GetItem(5);
		ControllerBase<PhotographController>.Instance.CloseBlackScreen().Forget();
	}

	// Token: 0x06012F0D RID: 77581 RVA: 0x0053CE1C File Offset: 0x0053B01C
	protected override void OnBeforeDestroy()
	{
		if (this.InfoLayout != null)
		{
			this.InfoLayout.ClearChildren();
			this.InfoLayout = null;
		}
		this.NodeIconMap.Clear();
		this.MissionsInfoMap.Clear();
		this.InfoIconMap.Clear();
		this.FatherIcon = null;
	}

	// Token: 0x06012F0E RID: 77582 RVA: 0x0053CE6C File Offset: 0x0053B06C
	public void Refresh(List<IInfoData> infoList)
	{
		this.MissionsInfoMap.Clear();
		int count = infoList.Count;
		for (int i = 0; i < count; i++)
		{
			this.MissionsInfoMap.Add(infoList[i].Text, i);
		}
		this.InfoLayout.RebuildLayoutByDataNew<IInfoData>(infoList, null);
	}

	// Token: 0x06012F0F RID: 77583 RVA: 0x0053CEC4 File Offset: 0x0053B0C4
	public void SetInfoPanelVisible(bool bVisible)
	{
		base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(bVisible);
	}

	// Token: 0x06012F10 RID: 77584 RVA: 0x0053CEEC File Offset: 0x0053B0EC
	public void UpdateIcons(List<IPositionData> positionList, [Nullable(2)] EntityPhotoBehaviorNode node)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (IPositionData positionData in positionList)
		{
			hashSet.Add(positionData.Id);
		}
		foreach (IPositionData positionData2 in positionList)
		{
			if (!this.InfoIconMap.ContainsKey(positionData2.Id))
			{
				EntityIconItem entityIconItem = new EntityIconItem(Singleton<LguiUtil>.Instance.CopyItem(this.FatherIcon, base.GetItem(0)));
				entityIconItem.CreateByActorAsync(entityIconItem.GetItsItem().GetOwner(), null, false).Forget();
				if (entityIconItem == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Photo;
					ELogAuthor author = ELogAuthor.JYS;
					string message = "tempUiItem为空";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名称：", positionData2.Id);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					entityIconItem.SetUiActive(true);
					entityIconItem.InitSpr();
					this.InfoIconMap.Add(positionData2.Id, entityIconItem);
					if (this.NodeIconMap.ContainsKey(node))
					{
						List<EntityIconItem> list = this.NodeIconMap[node];
						if (list != null && !list.Contains(entityIconItem))
						{
							list.Add(entityIconItem);
							this.NodeIconMap[node] = list;
						}
					}
					else
					{
						List<EntityIconItem> list2 = new List<EntityIconItem>();
						list2.Add(entityIconItem);
						this.NodeIconMap.Add(node, list2);
					}
					this.Move(entityIconItem, new FVector2D?(positionData2.Vector), true, positionData2.IsOptional, positionData2.IsOptionalFinished, node);
				}
			}
			else
			{
				EntityIconItem entityIcon = this.InfoIconMap[positionData2.Id];
				this.Move(entityIcon, new FVector2D?(positionData2.Vector), positionData2.NotShow, positionData2.IsOptional, positionData2.IsOptionalFinished, node);
			}
		}
		List<EntityIconItem> list3;
		if (node != null && this.NodeIconMap.TryGetValue(node, out list3))
		{
			foreach (KeyValuePair<string, EntityIconItem> keyValuePair in this.InfoIconMap)
			{
				if (list3.Contains(keyValuePair.Value) && !hashSet.Contains(keyValuePair.Key))
				{
					this.Move(keyValuePair.Value, null, true, false, false, node);
				}
			}
		}
	}

	// Token: 0x06012F11 RID: 77585 RVA: 0x0053D1A4 File Offset: 0x0053B3A4
	public void Move(EntityIconItem entityIcon, FVector2D? vector2D, bool bNotShow, bool bIsOptional, bool bIsOptionalFinished, EntityPhotoBehaviorNode node)
	{
		UUIItem itsItem = entityIcon.GetItsItem();
		itsItem.SetUIActive(true);
		if (vector2D != null)
		{
			itsItem.SetAnchorOffset(vector2D.Value);
		}
		if (bIsOptionalFinished || bNotShow)
		{
			entityIcon.UpdateNowIcon(ESprColor.None);
			return;
		}
		if (bIsOptional)
		{
			entityIcon.UpdateNowIcon(ESprColor.Green);
			return;
		}
		bool flag = false;
		if (node.RangeEntity != 0 && ControllerBase<PhotographController>.Instance.PhotoMissionFinishMap.TryGetValue(node.RangeEntity, out flag))
		{
			entityIcon.UpdateNowIcon(flag ? ESprColor.Green : ESprColor.Yellow);
			return;
		}
		entityIcon.UpdateNowIcon(ESprColor.Yellow);
	}

	// Token: 0x06012F12 RID: 77586 RVA: 0x0053D22C File Offset: 0x0053B42C
	[return: Nullable(2)]
	public EntityInfoItem GetInfoItemByDesc(string id)
	{
		int index;
		if (this.MissionsInfoMap.TryGetValue(id, out index))
		{
			return this.InfoLayout.GetLayoutItemByIndex(index);
		}
		return null;
	}

	// Token: 0x06012F13 RID: 77587 RVA: 0x0053D258 File Offset: 0x0053B458
	private ILayoutItem<EntityInfoItem> CreateInfoItem(object data, UUIItem uiItem, int index)
	{
		EntityInfoItem entityInfoItem = new EntityInfoItem();
		entityInfoItem.SetRootActor(uiItem.GetOwner(), true);
		entityInfoItem.InitSpr();
		entityInfoItem.Refresh((IInfoData)data);
		return new LayoutItem<EntityInfoItem>
		{
			Key = index,
			Value = entityInfoItem
		};
	}

	// Token: 0x040093DE RID: 37854
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<EntityInfoItem> InfoLayout;

	// Token: 0x040093DF RID: 37855
	[Nullable(2)]
	private UUIItem FatherIcon;

	// Token: 0x040093E0 RID: 37856
	private readonly Dictionary<string, int> MissionsInfoMap = new Dictionary<string, int>();

	// Token: 0x040093E1 RID: 37857
	private readonly Dictionary<EntityPhotoBehaviorNode, List<EntityIconItem>> NodeIconMap = new Dictionary<EntityPhotoBehaviorNode, List<EntityIconItem>>();

	// Token: 0x040093E2 RID: 37858
	private readonly Dictionary<string, EntityIconItem> InfoIconMap = new Dictionary<string, EntityIconItem>();

	// Token: 0x02008941 RID: 35137
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E4FB RID: 189691
		Panel,
		// Token: 0x0402E4FC RID: 189692
		PanelInfoLayout,
		// Token: 0x0402E4FD RID: 189693
		ItemInfo,
		// Token: 0x0402E4FE RID: 189694
		PanelArea,
		// Token: 0x0402E4FF RID: 189695
		PanelAreaGreen,
		// Token: 0x0402E500 RID: 189696
		TargetIcon
	}
}
