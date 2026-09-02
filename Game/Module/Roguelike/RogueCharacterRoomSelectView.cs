using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005170 RID: 20848
	public class RogueCharacterRoomSelectView : UiViewBase
	{
		// Token: 0x06035A62 RID: 219746 RVA: 0x00D79B18 File Offset: 0x00D77D18
		[NullableContext(1)]
		public RogueCharacterRoomSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035A63 RID: 219747 RVA: 0x00D79B28 File Offset: 0x00D77D28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.BtnConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A64 RID: 219748 RVA: 0x00D79C10 File Offset: 0x00D77E10
		private void BtnConfirmClick()
		{
			IRoguelikeCharacterSelectOpenParam roguelikeCharacterSelectOpenParam = this.OpenParam as IRoguelikeCharacterSelectOpenParam;
			ControllerBase<RoguelikeController>.Instance.RoguelikeRoleRoomSelectRequest(this.SelectRoomId, roguelikeCharacterSelectOpenParam.Index).ContinueWith(delegate(bool _)
			{
				base.CloseMe(null);
			}).Forget();
		}

		// Token: 0x06035A65 RID: 219749 RVA: 0x00D79C58 File Offset: 0x00D77E58
		private void OnSelectRoom(int gridIndex, bool isSelected, int roomId)
		{
			if (isSelected)
			{
				GenericLayout<RogueCharacterRoomItem, int> genericLayout = this.GenericLayout;
				if (genericLayout != null)
				{
					genericLayout.DeselectCurrentGridProxy();
				}
				GenericLayout<RogueCharacterRoomItem, int> genericLayout2 = this.GenericLayout;
				if (genericLayout2 != null)
				{
					genericLayout2.SelectGridProxy(gridIndex, false);
				}
				this.SelectRoomId = roomId;
			}
			else
			{
				GenericLayout<RogueCharacterRoomItem, int> genericLayout3 = this.GenericLayout;
				if (genericLayout3 != null)
				{
					genericLayout3.DeselectCurrentGridProxy();
				}
			}
			base.GetButton(3).SetSelfInteractive(isSelected);
		}

		// Token: 0x06035A66 RID: 219750 RVA: 0x00D79CB4 File Offset: 0x00D77EB4
		protected override UniTask OnBeforeStartAsync()
		{
			RogueCharacterRoomSelectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueCharacterRoomSelectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401ECD8 RID: 126168
		[Nullable(2)]
		private TopPanel TopPanelComponent;

		// Token: 0x0401ECD9 RID: 126169
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueCharacterRoomItem, int> GenericLayout;

		// Token: 0x0401ECDA RID: 126170
		private int SelectRoomId = -1;

		// Token: 0x0200B120 RID: 45344
		private class ERogueCharacterRoomSelectViewDefine
		{
			// Token: 0x04036F0D RID: 225037
			public const int TopPanel = 0;

			// Token: 0x04036F0E RID: 225038
			public const int PanelLayout = 1;

			// Token: 0x04036F0F RID: 225039
			public const int RoomSelectItem = 2;

			// Token: 0x04036F10 RID: 225040
			public const int BtnConfirm = 3;
		}
	}
}
