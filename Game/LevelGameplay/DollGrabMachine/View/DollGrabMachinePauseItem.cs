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
	// Token: 0x02006F0C RID: 28428
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachinePauseItem : UiPanelBase, IGridProxy<IGrabItemData>
	{
		// Token: 0x1700A43F RID: 42047
		// (get) Token: 0x06044DDA RID: 282074 RVA: 0x011EBC5F File Offset: 0x011E9E5F
		// (set) Token: 0x06044DDB RID: 282075 RVA: 0x011EBC67 File Offset: 0x011E9E67
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

		// Token: 0x1700A440 RID: 42048
		// (get) Token: 0x06044DDC RID: 282076 RVA: 0x011EBC70 File Offset: 0x011E9E70
		// (set) Token: 0x06044DDD RID: 282077 RVA: 0x011EBC78 File Offset: 0x011E9E78
		public int GridIndex { get; set; }

		// Token: 0x1700A441 RID: 42049
		// (get) Token: 0x06044DDE RID: 282078 RVA: 0x011EBC81 File Offset: 0x011E9E81
		// (set) Token: 0x06044DDF RID: 282079 RVA: 0x011EBC89 File Offset: 0x011E9E89
		public int DisplayIndex { get; set; }

		// Token: 0x06044DE0 RID: 282080 RVA: 0x011EBC94 File Offset: 0x011E9E94
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

		// Token: 0x06044DE1 RID: 282081 RVA: 0x011EBCFD File Offset: 0x011E9EFD
		public void Refresh(IGrabItemData data, bool isSelected, int gridIndex)
		{
			this.RefreshAsync(data, isSelected, gridIndex).Forget();
		}

		// Token: 0x06044DE2 RID: 282082 RVA: 0x011EBD10 File Offset: 0x011E9F10
		public UniTask RefreshAsync(IGrabItemData data, bool isSelected, int gridIndex)
		{
			DollGrabMachinePauseItem.<RefreshAsync>d__14 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<DollGrabMachinePauseItem.<RefreshAsync>d__14>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044DE3 RID: 282083 RVA: 0x011EBD5B File Offset: 0x011E9F5B
		public void Clear()
		{
		}

		// Token: 0x06044DE4 RID: 282084 RVA: 0x011EBD5D File Offset: 0x011E9F5D
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06044DE5 RID: 282085 RVA: 0x011EBD5F File Offset: 0x011E9F5F
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06044DE6 RID: 282086 RVA: 0x011EBD61 File Offset: 0x011E9F61
		public object GetKey(IGrabItemData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
