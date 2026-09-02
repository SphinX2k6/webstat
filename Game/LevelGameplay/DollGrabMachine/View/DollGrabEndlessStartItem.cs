using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EEE RID: 28398
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabEndlessStartItem : UiPanelBase, IGridProxy<IGrabItemData>
	{
		// Token: 0x1700A436 RID: 42038
		// (get) Token: 0x06044D4F RID: 281935 RVA: 0x011E92E1 File Offset: 0x011E74E1
		// (set) Token: 0x06044D50 RID: 281936 RVA: 0x011E92E9 File Offset: 0x011E74E9
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<IGrabItemData>, IGrabItemData> ScrollViewDelegate { [return: Nullable(new byte[]
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

		// Token: 0x1700A437 RID: 42039
		// (get) Token: 0x06044D51 RID: 281937 RVA: 0x011E92F2 File Offset: 0x011E74F2
		// (set) Token: 0x06044D52 RID: 281938 RVA: 0x011E92FA File Offset: 0x011E74FA
		public int GridIndex { get; set; }

		// Token: 0x1700A438 RID: 42040
		// (get) Token: 0x06044D53 RID: 281939 RVA: 0x011E9303 File Offset: 0x011E7503
		// (set) Token: 0x06044D54 RID: 281940 RVA: 0x011E930B File Offset: 0x011E750B
		public int DisplayIndex { get; set; }

		// Token: 0x06044D55 RID: 281941 RVA: 0x011E9314 File Offset: 0x011E7514
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044D56 RID: 281942 RVA: 0x011E937D File Offset: 0x011E757D
		public void Refresh(IGrabItemData data, bool isSelected, int gridIndex)
		{
			this.RefreshAsync(data, isSelected, gridIndex).Forget();
		}

		// Token: 0x06044D57 RID: 281943 RVA: 0x011E9390 File Offset: 0x011E7590
		public UniTask RefreshAsync(IGrabItemData data, bool isSelected, int gridIndex)
		{
			DollGrabEndlessStartItem.<RefreshAsync>d__14 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<DollGrabEndlessStartItem.<RefreshAsync>d__14>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044D58 RID: 281944 RVA: 0x011E93DB File Offset: 0x011E75DB
		public void Clear()
		{
		}

		// Token: 0x06044D59 RID: 281945 RVA: 0x011E93DD File Offset: 0x011E75DD
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06044D5A RID: 281946 RVA: 0x011E93DF File Offset: 0x011E75DF
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06044D5B RID: 281947 RVA: 0x011E93E1 File Offset: 0x011E75E1
		public object GetKey(IGrabItemData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
