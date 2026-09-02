using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006368 RID: 25448
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TabItem : GridProxyAbstract<Spring25LetterListTabData>
	{
		// Token: 0x17009CDD RID: 40157
		// (get) Token: 0x0603FE53 RID: 261715 RVA: 0x01063A9F File Offset: 0x01061C9F
		// (set) Token: 0x0603FE54 RID: 261716 RVA: 0x01063AA7 File Offset: 0x01061CA7
		private Spring25LetterListTabData DataCache { get; set; }

		// Token: 0x0603FE55 RID: 261717 RVA: 0x01063AB0 File Offset: 0x01061CB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.HandleClickTab));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FE56 RID: 261718 RVA: 0x01063B98 File Offset: 0x01061D98
		protected override UniTask OnBeforeStartAsync()
		{
			TabItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TabItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE57 RID: 261719 RVA: 0x01063BDB File Offset: 0x01061DDB
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Unbind();
		}

		// Token: 0x0603FE58 RID: 261720 RVA: 0x01063BF4 File Offset: 0x01061DF4
		public override void Refresh(Spring25LetterListTabData data, bool isSelected, int gridIndex)
		{
			this.DataCache = data;
			UUITexture texture = base.GetTexture(1);
			base.TrySetTextureByPath(data.TexturePath, texture, null, null);
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, data.DescriptionTextId, Array.Empty<object>());
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.IsNew);
		}

		// Token: 0x0603FE59 RID: 261721 RVA: 0x01063C7C File Offset: 0x01061E7C
		private void HandleClickTab(EToggleState toggleState)
		{
			if (this.DataCache == null)
			{
				return;
			}
			ControllerBase<ActivitySpring25Controller>.Instance.HandleLetterClickInLetterListView(this.DataCache.SignId);
		}

		// Token: 0x0603FE5A RID: 261722 RVA: 0x01063C9C File Offset: 0x01061E9C
		private bool HandleCanExecuteChange()
		{
			return this.DataCache != null && !this.DataCache.IsChosen;
		}

		// Token: 0x0200C3D2 RID: 50130
		[NullableContext(0)]
		private class ETabComponent
		{
			// Token: 0x0403C514 RID: 247060
			public const int RootToggle = 0;

			// Token: 0x0403C515 RID: 247061
			public const int HeadTexture = 1;

			// Token: 0x0403C516 RID: 247062
			public const int DescriptionText = 2;

			// Token: 0x0403C517 RID: 247063
			public const int NewItem = 3;
		}
	}
}
