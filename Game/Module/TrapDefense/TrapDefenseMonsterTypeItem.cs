using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E41 RID: 20033
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseMonsterTypeItem : GridProxyAbstract<TrapDefenseMonsterTypeData>
	{
		// Token: 0x06033C71 RID: 212081 RVA: 0x00CF13D8 File Offset: 0x00CEF5D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C72 RID: 212082 RVA: 0x00CF1484 File Offset: 0x00CEF684
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMonsterTypeItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMonsterTypeItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C73 RID: 212083 RVA: 0x00CF14C8 File Offset: 0x00CEF6C8
		public override UniTask RefreshAsync(TrapDefenseMonsterTypeData data, bool isSelected, int gridIndex)
		{
			TrapDefenseMonsterTypeItem.<RefreshAsync>d__9 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TrapDefenseMonsterTypeItem.<RefreshAsync>d__9>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C74 RID: 212084 RVA: 0x00CF1513 File Offset: 0x00CEF713
		public TrapDefenseMonsterItem CreateItemMonster()
		{
			return new TrapDefenseMonsterItem(false)
			{
				OnSelectMonsterItemCallback = new Action<TrapDefenseMonsterData>(this.OnSelectMonsterItem)
			};
		}

		// Token: 0x06033C75 RID: 212085 RVA: 0x00CF152D File Offset: 0x00CEF72D
		public override void OnSelected(bool isSelected)
		{
			if (!this.IsFireForBuffClick)
			{
				this.LayoutMonster.SelectGridProxy(Math.Max(this.LastSelectMonsterIndex, 0), false);
			}
		}

		// Token: 0x06033C76 RID: 212086 RVA: 0x00CF154F File Offset: 0x00CEF74F
		public override void OnDeselected(bool isSelected)
		{
			this.LayoutMonster.DeselectCurrentGridProxy();
		}

		// Token: 0x06033C77 RID: 212087 RVA: 0x00CF155C File Offset: 0x00CEF75C
		private void OnSelectMonsterItem(TrapDefenseMonsterData data)
		{
			this.IsFireForBuffClick = true;
			IScrollViewDelegate<IGridProxy<TrapDefenseMonsterTypeData>, TrapDefenseMonsterTypeData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate != null)
			{
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
			}
			Action<TrapDefenseMonsterData> onSelectMonsterCallBack = this.OnSelectMonsterCallBack;
			if (onSelectMonsterCallBack != null)
			{
				onSelectMonsterCallBack(data);
			}
			this.IsFireForBuffClick = false;
		}

		// Token: 0x0401DF69 RID: 122729
		public TrapDefenseMonsterTypeData ItemData;

		// Token: 0x0401DF6A RID: 122730
		public Action<TrapDefenseMonsterTypeData> ClickCallBack;

		// Token: 0x0401DF6B RID: 122731
		public Action<TrapDefenseMonsterData> OnSelectMonsterCallBack;

		// Token: 0x0401DF6C RID: 122732
		public GenericLayout<TrapDefenseMonsterItem, TrapDefenseMonsterData> LayoutMonster;

		// Token: 0x0401DF6D RID: 122733
		public int LastSelectMonsterIndex = -1;

		// Token: 0x0401DF6E RID: 122734
		public bool IsFireForBuffClick;

		// Token: 0x0200ADCB RID: 44491
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F7C RID: 221052
			public const int SpriteIconType = 0;

			// Token: 0x04035F7D RID: 221053
			public const int TextNameType = 1;

			// Token: 0x04035F7E RID: 221054
			public const int LayoutMonster = 2;

			// Token: 0x04035F7F RID: 221055
			public const int ItemMonster = 3;
		}
	}
}
