using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013A2 RID: 5026
public class BuildingMapShowRoleModule : UiPanelBase
{
	// Token: 0x06008A7D RID: 35453 RVA: 0x002474CC File Offset: 0x002456CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUITexture))
		};
	}

	// Token: 0x06008A7E RID: 35454 RVA: 0x00247608 File Offset: 0x00245808
	[NullableContext(1)]
	protected List<UUITexture> GetRoleTextureList()
	{
		return new List<UUITexture>
		{
			base.GetTexture(0),
			base.GetTexture(1),
			base.GetTexture(2),
			base.GetTexture(3),
			base.GetTexture(4),
			base.GetTexture(5),
			base.GetTexture(6),
			base.GetTexture(7),
			base.GetTexture(8),
			base.GetTexture(9),
			base.GetTexture(10),
			base.GetTexture(11),
			base.GetTexture(12)
		};
	}

	// Token: 0x06008A7F RID: 35455 RVA: 0x002476C8 File Offset: 0x002458C8
	protected override UniTask OnBeforeStartAsync()
	{
		BuildingMapShowRoleModule.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BuildingMapShowRoleModule.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x02007750 RID: 30544
	private static class EComponents
	{
		// Token: 0x04029159 RID: 168281
		public const int RoleItem1 = 0;

		// Token: 0x0402915A RID: 168282
		public const int RoleItem2 = 1;

		// Token: 0x0402915B RID: 168283
		public const int RoleItem3 = 2;

		// Token: 0x0402915C RID: 168284
		public const int RoleItem4 = 3;

		// Token: 0x0402915D RID: 168285
		public const int RoleItem5 = 4;

		// Token: 0x0402915E RID: 168286
		public const int RoleItem6 = 5;

		// Token: 0x0402915F RID: 168287
		public const int RoleItem7 = 6;

		// Token: 0x04029160 RID: 168288
		public const int RoleItem8 = 7;

		// Token: 0x04029161 RID: 168289
		public const int RoleItem9 = 8;

		// Token: 0x04029162 RID: 168290
		public const int RoleItem10 = 9;

		// Token: 0x04029163 RID: 168291
		public const int RoleItem11 = 10;

		// Token: 0x04029164 RID: 168292
		public const int RoleItem12 = 11;

		// Token: 0x04029165 RID: 168293
		public const int RoleItem13 = 12;
	}
}
