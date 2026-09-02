using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013A5 RID: 5029
public class BuildingRoleItem : UiPanelBase
{
	// Token: 0x06008A98 RID: 35480 RVA: 0x00247DE8 File Offset: 0x00245FE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06008A99 RID: 35481 RVA: 0x00247E42 File Offset: 0x00246042
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008A9A RID: 35482 RVA: 0x00247E58 File Offset: 0x00246058
	public UniTask RefreshSpine(int roleId)
	{
		BuildingRoleItem.<RefreshSpine>d__3 <RefreshSpine>d__;
		<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSpine>d__.<>4__this = this;
		<RefreshSpine>d__.roleId = roleId;
		<RefreshSpine>d__.<>1__state = -1;
		<RefreshSpine>d__.<>t__builder.Start<BuildingRoleItem.<RefreshSpine>d__3>(ref <RefreshSpine>d__);
		return <RefreshSpine>d__.<>t__builder.Task;
	}

	// Token: 0x0200775F RID: 30559
	private static class EComponentDefine
	{
		// Token: 0x040291A7 RID: 168359
		public const int Spine = 0;

		// Token: 0x040291A8 RID: 168360
		public const int DialogItem = 1;

		// Token: 0x040291A9 RID: 168361
		public const int Dialog = 2;
	}
}
