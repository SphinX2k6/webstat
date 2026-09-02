using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066DF RID: 26335
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightTalentGridPanel : UiPanelBase, IGridProxy<List<MotorFightTalentData>>
	{
		// Token: 0x1700A095 RID: 41109
		// (get) Token: 0x06041BFB RID: 269307 RVA: 0x010DD3E2 File Offset: 0x010DB5E2
		// (set) Token: 0x06041BFC RID: 269308 RVA: 0x010DD3EA File Offset: 0x010DB5EA
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<List<MotorFightTalentData>>, List<MotorFightTalentData>> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1,
			1
		})] set; }

		// Token: 0x1700A096 RID: 41110
		// (get) Token: 0x06041BFD RID: 269309 RVA: 0x010DD3F3 File Offset: 0x010DB5F3
		// (set) Token: 0x06041BFE RID: 269310 RVA: 0x010DD3FB File Offset: 0x010DB5FB
		public int GridIndex { get; set; }

		// Token: 0x1700A097 RID: 41111
		// (get) Token: 0x06041BFF RID: 269311 RVA: 0x010DD404 File Offset: 0x010DB604
		// (set) Token: 0x06041C00 RID: 269312 RVA: 0x010DD40C File Offset: 0x010DB60C
		public int DisplayIndex { get; set; }

		// Token: 0x06041C01 RID: 269313 RVA: 0x010DD418 File Offset: 0x010DB618
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C02 RID: 269314 RVA: 0x010DD4A4 File Offset: 0x010DB6A4
		public UniTask RefreshAsync(List<MotorFightTalentData> dataList, bool isSelected, int gridIndex)
		{
			MotorFightTalentGridPanel.<RefreshAsync>d__16 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.dataList = dataList;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<MotorFightTalentGridPanel.<RefreshAsync>d__16>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C03 RID: 269315 RVA: 0x010DD4EF File Offset: 0x010DB6EF
		public void Clear()
		{
		}

		// Token: 0x06041C04 RID: 269316 RVA: 0x010DD4F1 File Offset: 0x010DB6F1
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06041C05 RID: 269317 RVA: 0x010DD4F3 File Offset: 0x010DB6F3
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06041C06 RID: 269318 RVA: 0x010DD4F5 File Offset: 0x010DB6F5
		public object GetKey(List<MotorFightTalentData> data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x04024AF1 RID: 150257
		private readonly List<MotorFightTalentNodeItem> TalentNodeItemList = new List<MotorFightTalentNodeItem>();

		// Token: 0x04024AF5 RID: 150261
		public Action<MotorFightTalentNodeItem> OnSelectTalentNode = delegate(MotorFightTalentNodeItem technologyNode)
		{
		};

		// Token: 0x0200C70F RID: 50959
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D49E RID: 251038
			public const int Pos1 = 0;

			// Token: 0x0403D49F RID: 251039
			public const int Pos2 = 1;

			// Token: 0x0403D4A0 RID: 251040
			public const int Pos3 = 2;
		}
	}
}
