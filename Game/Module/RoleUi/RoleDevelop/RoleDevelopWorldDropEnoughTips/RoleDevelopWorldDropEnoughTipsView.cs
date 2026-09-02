using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.RoleDevelopWorldDropEnoughTips
{
	// Token: 0x020050D4 RID: 20692
	public class RoleDevelopWorldDropEnoughTipsView : UiTickViewBase
	{
		// Token: 0x0603551D RID: 218397 RVA: 0x00D60A5A File Offset: 0x00D5EC5A
		[NullableContext(1)]
		public RoleDevelopWorldDropEnoughTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603551E RID: 218398 RVA: 0x00D60A64 File Offset: 0x00D5EC64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603551F RID: 218399 RVA: 0x00D60AAC File Offset: 0x00D5ECAC
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x06035520 RID: 218400 RVA: 0x00D60AB4 File Offset: 0x00D5ECB4
		protected override void OnAfterDestroy()
		{
			RoleDevelopWorldDropEnoughTipsController.TryShowNext();
		}

		// Token: 0x06035521 RID: 218401 RVA: 0x00D60ABC File Offset: 0x00D5ECBC
		private void Refresh()
		{
			int? currentDisplayItemId = RoleDevelopWorldDropEnoughTipsController.GetCurrentDisplayItemId();
			if (currentDisplayItemId == null)
			{
				return;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(currentDisplayItemId.Value);
			if (itemConfigData != null)
			{
				base.SetTextureByPath(itemConfigData.Icon, base.GetTexture(0), null, null);
			}
		}

		// Token: 0x06035522 RID: 218402 RVA: 0x00D60B0B File Offset: 0x00D5ED0B
		protected override void OnAfterPlayStartSequence()
		{
			this.PlaySequenceStream().ContinueWith(delegate()
			{
				base.CloseMe(null);
			}).Forget();
		}

		// Token: 0x06035523 RID: 218403 RVA: 0x00D60B2C File Offset: 0x00D5ED2C
		private UniTask PlaySequenceStream()
		{
			RoleDevelopWorldDropEnoughTipsView.<PlaySequenceStream>d__7 <PlaySequenceStream>d__;
			<PlaySequenceStream>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceStream>d__.<>1__state = -1;
			<PlaySequenceStream>d__.<>t__builder.Start<RoleDevelopWorldDropEnoughTipsView.<PlaySequenceStream>d__7>(ref <PlaySequenceStream>d__);
			return <PlaySequenceStream>d__.<>t__builder.Task;
		}

		// Token: 0x0200B073 RID: 45171
		private class EComponent
		{
			// Token: 0x04036C02 RID: 224258
			public const int TexIcon = 0;
		}
	}
}
