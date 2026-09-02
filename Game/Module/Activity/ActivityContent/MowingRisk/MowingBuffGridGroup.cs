using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669B RID: 26267
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MowingBuffGridGroup : GridProxyAbstract<IMowingBuffGridGroupData>
	{
		// Token: 0x0604198D RID: 268685 RVA: 0x010D1828 File Offset: 0x010CFA28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604198E RID: 268686 RVA: 0x010D18B2 File Offset: 0x010CFAB2
		protected override void OnStart()
		{
			this.GridLayout = new GenericLayout<MowingBuffGridItem, IMowingBuffGridItemData>(base.GetGridLayout(1), new Func<MowingBuffGridItem>(this.BuildGridItem), null, false, true);
		}

		// Token: 0x0604198F RID: 268687 RVA: 0x010D18D5 File Offset: 0x010CFAD5
		protected override void OnBeforeDestroy()
		{
			this.GridLayout.UnBindLateUpdate();
		}

		// Token: 0x06041990 RID: 268688 RVA: 0x010D18E4 File Offset: 0x010CFAE4
		public override UniTask RefreshAsync(IMowingBuffGridGroupData data, bool isSelected, int gridIndex)
		{
			MowingBuffGridGroup.<RefreshAsync>d__5 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<MowingBuffGridGroup.<RefreshAsync>d__5>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041991 RID: 268689 RVA: 0x010D192F File Offset: 0x010CFB2F
		private MowingBuffGridItem BuildGridItem()
		{
			return new MowingBuffGridItem();
		}

		// Token: 0x06041992 RID: 268690 RVA: 0x010D1936 File Offset: 0x010CFB36
		public GenericLayout<MowingBuffGridItem, IMowingBuffGridItemData> GetBuffGridItemLayout()
		{
			return this.GridLayout;
		}

		// Token: 0x04024A21 RID: 150049
		private GenericLayout<MowingBuffGridItem, IMowingBuffGridItemData> GridLayout;

		// Token: 0x0200C6A4 RID: 50852
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D29A RID: 250522
			public const int TitleText = 0;

			// Token: 0x0403D29B RID: 250523
			public const int GridLayout = 1;

			// Token: 0x0403D29C RID: 250524
			public const int GridItem = 2;
		}
	}
}
