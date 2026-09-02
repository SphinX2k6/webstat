using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002294 RID: 8852
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeComNodeItem : GridProxyAbstract<MotorTechTreeNode>
{
	// Token: 0x06010BC0 RID: 68544 RVA: 0x00495F48 File Offset: 0x00494148
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTechTreeNodeClick))
		};
	}

	// Token: 0x06010BC1 RID: 68545 RVA: 0x00496077 File Offset: 0x00494277
	protected override void OnStart()
	{
		this.LevelLayout = new GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint>(base.GetHorizontalLayout(7), new Func<MotorcycleTechTreeLevelItem>(this.InitLevelItem), null, false, true);
	}

	// Token: 0x06010BC2 RID: 68546 RVA: 0x0049609A File Offset: 0x0049429A
	public override void Refresh(MotorTechTreeNode data, bool isSelected, int gridIndex)
	{
		this.RefreshNodeAsyncByData(data).Forget();
	}

	// Token: 0x06010BC3 RID: 68547 RVA: 0x004960A8 File Offset: 0x004942A8
	public UniTask RefreshNodeAsync()
	{
		MotorcycleTechTreeComNodeItem.<RefreshNodeAsync>d__7 <RefreshNodeAsync>d__;
		<RefreshNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsync>d__.<>4__this = this;
		<RefreshNodeAsync>d__.<>1__state = -1;
		<RefreshNodeAsync>d__.<>t__builder.Start<MotorcycleTechTreeComNodeItem.<RefreshNodeAsync>d__7>(ref <RefreshNodeAsync>d__);
		return <RefreshNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BC4 RID: 68548 RVA: 0x004960EC File Offset: 0x004942EC
	[NullableContext(2)]
	public UniTask RefreshNodeAsyncByData(MotorTechTreeNode treeNode)
	{
		MotorcycleTechTreeComNodeItem.<RefreshNodeAsyncByData>d__8 <RefreshNodeAsyncByData>d__;
		<RefreshNodeAsyncByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsyncByData>d__.<>4__this = this;
		<RefreshNodeAsyncByData>d__.treeNode = treeNode;
		<RefreshNodeAsyncByData>d__.<>1__state = -1;
		<RefreshNodeAsyncByData>d__.<>t__builder.Start<MotorcycleTechTreeComNodeItem.<RefreshNodeAsyncByData>d__8>(ref <RefreshNodeAsyncByData>d__);
		return <RefreshNodeAsyncByData>d__.<>t__builder.Task;
	}

	// Token: 0x06010BC5 RID: 68549 RVA: 0x00496137 File Offset: 0x00494337
	private MotorcycleTechTreeLevelItem InitLevelItem()
	{
		return new MotorcycleTechTreeLevelItem();
	}

	// Token: 0x06010BC6 RID: 68550 RVA: 0x0049613E File Offset: 0x0049433E
	public void SelectNode()
	{
		this.InvokeOnClickToggleBack();
	}

	// Token: 0x06010BC7 RID: 68551 RVA: 0x00496146 File Offset: 0x00494346
	private void OnTechTreeNodeClick(EToggleState toggleState)
	{
		this.InvokeOnClickToggleBack();
	}

	// Token: 0x06010BC8 RID: 68552 RVA: 0x0049614E File Offset: 0x0049434E
	private void InvokeOnClickToggleBack()
	{
		Action<MotorTechTreeNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Node, base.GetExtendToggle(0));
	}

	// Token: 0x04008405 RID: 33797
	[Nullable(2)]
	public MotorTechTreeNode Node;

	// Token: 0x04008406 RID: 33798
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint> LevelLayout;

	// Token: 0x04008407 RID: 33799
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<MotorTechTreeNode, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x0200855F RID: 34143
	[NullableContext(0)]
	private class EMotorTreeComItemComponent
	{
		// Token: 0x0402D226 RID: 184870
		public const int TogItem = 0;

		// Token: 0x0402D227 RID: 184871
		public const int ActivateBgItem = 1;

		// Token: 0x0402D228 RID: 184872
		public const int TexIconActivate = 2;

		// Token: 0x0402D229 RID: 184873
		public const int LockBgItem = 3;

		// Token: 0x0402D22A RID: 184874
		public const int TexIconLock = 4;

		// Token: 0x0402D22B RID: 184875
		public const int LockItem = 5;

		// Token: 0x0402D22C RID: 184876
		public const int RedDotItem = 6;

		// Token: 0x0402D22D RID: 184877
		public const int LevelLayout = 7;

		// Token: 0x0402D22E RID: 184878
		public const int TopUnlockItem = 8;

		// Token: 0x0402D22F RID: 184879
		public const int ActivateBgIcon = 9;

		// Token: 0x0402D230 RID: 184880
		public const int TopLockItem = 10;
	}
}
