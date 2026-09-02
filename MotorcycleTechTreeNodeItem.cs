using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200229B RID: 8859
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeNodeItem : GridProxyAbstract<MotorTechTreeNode>
{
	// Token: 0x06010BEA RID: 68586 RVA: 0x004969E8 File Offset: 0x00494BE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTechTreeNodeClick))
		};
	}

	// Token: 0x06010BEB RID: 68587 RVA: 0x00496AE9 File Offset: 0x00494CE9
	protected override void OnStart()
	{
		this.LevelLayout = new GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint>(base.GetHorizontalLayout(8), new Func<MotorcycleTechTreeLevelItem>(this.InitLevelItem), null, false, true);
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06010BEC RID: 68588 RVA: 0x00496B20 File Offset: 0x00494D20
	protected override void OnBeforeShow()
	{
		if (this.Node != null)
		{
			this.SeqPlayer.StopSequenceByKey("Start", false, false);
			this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x06010BED RID: 68589 RVA: 0x00496B64 File Offset: 0x00494D64
	public void PlayNodeSequence()
	{
		if (this.HasPlayedSequence)
		{
			return;
		}
		this.SeqPlayer.StopSequenceByKey("Start", false, false);
		this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		this.HasPlayedSequence = true;
	}

	// Token: 0x06010BEE RID: 68590 RVA: 0x00496BB0 File Offset: 0x00494DB0
	public void RefreshNodeData(MotorTechTreeNode treeNode)
	{
		if (treeNode == null)
		{
			return;
		}
		this.Node = treeNode;
		MotorTech? motorTechConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechConfig(treeNode.NodeId);
		if (motorTechConfig == null)
		{
			return;
		}
		EMotorTechTreeNodeStatus status = treeNode.Status;
		bool flag = status == EMotorTechTreeNodeStatus.Lock;
		bool flag2 = status == EMotorTechTreeNodeStatus.Activated;
		bool flag3 = status == EMotorTechTreeNodeStatus.CanUnlock;
		bool flag4 = ModelBase<MotorcycleDevelopModel>.Instance.IsPreNodeActivated(treeNode);
		bool uiactive = flag || !flag4;
		UUIItem item = base.GetItem(1);
		UUISprite sprite = base.GetSprite(2);
		UUITexture texture = base.GetTexture(3);
		UUIItem item2 = base.GetItem(6);
		item.SetUIActive(false);
		sprite.SetUIActive(false);
		UUIItem uuiitem = texture;
		bool bUseChangeColor = false;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		item2.SetUIActive(false);
		base.GetItem(4).SetUIActive(uiactive);
		base.GetItem(7).SetUIActive(uiactive);
		bool flag5 = ModelBase<MotorcycleDevelopModel>.Instance.CanUpgradeNode(treeNode);
		if (flag3)
		{
			item.SetUIActive(true);
			sprite.SetUIActive(false);
			item2.SetUIActive(flag4 && flag5);
		}
		else if (flag2)
		{
			bool flag6 = treeNode.NodeLevel >= motorTechConfig.Value.GetTechLvArray().Length;
			item.SetUIActive(true);
			sprite.SetUIActive(true);
			UUIItem uuiitem2 = texture;
			bool bUseChangeColor2 = true;
			fcolor = new FColor?(texture.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			item2.SetUIActive(!flag6 && flag5);
		}
		int nodeLevel = treeNode.NodeLevel;
		List<IMotorTechLevelPoint> list = new List<IMotorTechLevelPoint>();
		for (int i = 0; i < motorTechConfig.Value.GetTechLvArray().Length; i++)
		{
			MotorTechLevelPoint item3 = new MotorTechLevelPoint
			{
				TargetLevel = i + 1,
				CurLevel = nodeLevel
			};
			list.Add(item3);
		}
		base.SetTextureByPath(motorTechConfig.Value.Icon, base.GetTexture(3), null, null);
		base.SetTextureByPath(motorTechConfig.Value.Icon, base.GetTexture(5), null, null);
		this.LevelLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06010BEF RID: 68591 RVA: 0x00496DB4 File Offset: 0x00494FB4
	[NullableContext(1)]
	public override void Refresh(MotorTechTreeNode data, bool isSelected, int gridIndex)
	{
		this.RefreshNodeData(data);
	}

	// Token: 0x06010BF0 RID: 68592 RVA: 0x00496DBD File Offset: 0x00494FBD
	[NullableContext(1)]
	private MotorcycleTechTreeLevelItem InitLevelItem()
	{
		return new MotorcycleTechTreeLevelItem();
	}

	// Token: 0x06010BF1 RID: 68593 RVA: 0x00496DC4 File Offset: 0x00494FC4
	public void SelectNode()
	{
		this.OnSelectTechTreeNode();
	}

	// Token: 0x06010BF2 RID: 68594 RVA: 0x00496DCC File Offset: 0x00494FCC
	private void OnTechTreeNodeClick(EToggleState toggleState)
	{
		this.OnSelectTechTreeNode();
	}

	// Token: 0x06010BF3 RID: 68595 RVA: 0x00496DD4 File Offset: 0x00494FD4
	private void OnSelectTechTreeNode()
	{
		Action<MotorTechTreeNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Node, base.GetExtendToggle(0));
	}

	// Token: 0x04008413 RID: 33811
	public MotorTechTreeNode Node;

	// Token: 0x04008414 RID: 33812
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint> LevelLayout;

	// Token: 0x04008415 RID: 33813
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008416 RID: 33814
	private bool HasPlayedSequence;

	// Token: 0x04008417 RID: 33815
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<MotorTechTreeNode, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x0200856E RID: 34158
	[NullableContext(0)]
	private class EMotorTreeNodeItemComponent
	{
		// Token: 0x0402D26B RID: 184939
		public const int TogItem = 0;

		// Token: 0x0402D26C RID: 184940
		public const int ActivateBgItem = 1;

		// Token: 0x0402D26D RID: 184941
		public const int SprActivate = 2;

		// Token: 0x0402D26E RID: 184942
		public const int TexIconActivate = 3;

		// Token: 0x0402D26F RID: 184943
		public const int LockBgItem = 4;

		// Token: 0x0402D270 RID: 184944
		public const int TexIconLock = 5;

		// Token: 0x0402D271 RID: 184945
		public const int RedDotItem = 6;

		// Token: 0x0402D272 RID: 184946
		public const int LockItem = 7;

		// Token: 0x0402D273 RID: 184947
		public const int LevelLayout = 8;
	}
}
