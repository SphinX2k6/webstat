using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005171 RID: 20849
	public class RogueCharacterRoomItem : GridProxyAbstract<int>
	{
		// Token: 0x06035A6A RID: 219754 RVA: 0x00D79D24 File Offset: 0x00D77F24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.ToggleCallBackInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A6B RID: 219755 RVA: 0x00D79E30 File Offset: 0x00D78030
		protected override UniTask OnBeforeStartAsync()
		{
			RogueCharacterRoomItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueCharacterRoomItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A6C RID: 219756 RVA: 0x00D79E73 File Offset: 0x00D78073
		[NullableContext(1)]
		private CommonElementItem CreateElement()
		{
			return new CommonElementItem();
		}

		// Token: 0x06035A6D RID: 219757 RVA: 0x00D79E7A File Offset: 0x00D7807A
		public void SetItemToggleState(EToggleState state)
		{
			base.GetExtendToggle(3).SetToggleState(state, false, false, false);
		}

		// Token: 0x06035A6E RID: 219758 RVA: 0x00D79E8D File Offset: 0x00D7808D
		private void ToggleCallBackInternal(EToggleState state)
		{
			if (this.ClickCallback != null)
			{
				this.ClickCallback(base.GridIndex, this.IsSelectRoom(), this.RoomId);
			}
		}

		// Token: 0x06035A6F RID: 219759 RVA: 0x00D79EB4 File Offset: 0x00D780B4
		public override void OnDeselected(bool fireEvent)
		{
			this.SetItemToggleState(EToggleState.ETT_UnChecked);
		}

		// Token: 0x06035A70 RID: 219760 RVA: 0x00D79EBD File Offset: 0x00D780BD
		public override void OnSelected(bool fireEvent)
		{
			this.SetItemToggleState(EToggleState.ETT_Checked);
		}

		// Token: 0x06035A71 RID: 219761 RVA: 0x00D79EC6 File Offset: 0x00D780C6
		public bool IsSelectRoom()
		{
			return base.GetExtendToggle(3).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x06035A72 RID: 219762 RVA: 0x00D79ED8 File Offset: 0x00D780D8
		public override void Refresh(int roomId, bool isSelected, int gridIndex)
		{
			this.RoomId = roomId;
			RogueRoomShowConfig? rogueRoomShowConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueRoomShowConfig(roomId);
			if (rogueRoomShowConfig == null)
			{
				return;
			}
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(rogueRoomShowConfig.Value.BuffId);
			if (rogueBuffConfig == null)
			{
				return;
			}
			List<int> list = null;
			foreach (DicIntInt dicIntInt in rogueBuffConfig.Value.BuffElementIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				list = new List<int>();
				for (int i = 0; i < value; i++)
				{
					list.Add(key);
				}
			}
			if (list != null)
			{
				GenericLayout<CommonElementItem, int> genericLayout = this.GenericLayout;
				if (genericLayout != null)
				{
					genericLayout.RefreshByData(list, null, false);
				}
			}
			base.SetTextureByPath(rogueRoomShowConfig.Value.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueRoomShowConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueRoomShowConfig.Value.Desc, Array.Empty<object>());
		}

		// Token: 0x0401ECDB RID: 126171
		[Nullable(2)]
		public Action<int, bool, int> ClickCallback;

		// Token: 0x0401ECDC RID: 126172
		public int RoomId = -1;

		// Token: 0x0401ECDD RID: 126173
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonElementItem, int> GenericLayout;

		// Token: 0x0200B122 RID: 45346
		private class ERogueCharacterRoomItemDefine
		{
			// Token: 0x04036F15 RID: 225045
			public const int TextureIcon = 0;

			// Token: 0x04036F16 RID: 225046
			public const int TxtName = 1;

			// Token: 0x04036F17 RID: 225047
			public const int TxtDesc = 2;

			// Token: 0x04036F18 RID: 225048
			public const int ExtendToggle = 3;

			// Token: 0x04036F19 RID: 225049
			public const int ElementLayout = 4;
		}
	}
}
