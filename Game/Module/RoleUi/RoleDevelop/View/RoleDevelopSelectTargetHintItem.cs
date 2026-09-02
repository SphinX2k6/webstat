using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050CC RID: 20684
	public class RoleDevelopSelectTargetHintItem : UiPanelBase, IGridProxy<RoleDevelopSelectTargetHintItemData>
	{
		// Token: 0x060354CB RID: 218315 RVA: 0x00D5F030 File Offset: 0x00D5D230
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

		// Token: 0x060354CC RID: 218316 RVA: 0x00D5F09C File Offset: 0x00D5D29C
		[NullableContext(1)]
		public void Refresh(RoleDevelopSelectTargetHintItemData data, bool isSelected, int gridIndex)
		{
			UUITexture texture = base.GetTexture(0);
			UUIText text = base.GetText(1);
			base.SetTextureShowUntilLoaded(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.IconKey), texture, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.DescKey, Array.Empty<object>());
		}

		// Token: 0x17008C23 RID: 35875
		// (get) Token: 0x060354CD RID: 218317 RVA: 0x00D5F0E7 File Offset: 0x00D5D2E7
		// (set) Token: 0x060354CE RID: 218318 RVA: 0x00D5F0EF File Offset: 0x00D5D2EF
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<RoleDevelopSelectTargetHintItemData>, RoleDevelopSelectTargetHintItemData> ScrollViewDelegate { [return: Nullable(new byte[]
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

		// Token: 0x17008C24 RID: 35876
		// (get) Token: 0x060354CF RID: 218319 RVA: 0x00D5F0F8 File Offset: 0x00D5D2F8
		// (set) Token: 0x060354D0 RID: 218320 RVA: 0x00D5F100 File Offset: 0x00D5D300
		public int GridIndex { get; set; }

		// Token: 0x17008C25 RID: 35877
		// (get) Token: 0x060354D1 RID: 218321 RVA: 0x00D5F109 File Offset: 0x00D5D309
		// (set) Token: 0x060354D2 RID: 218322 RVA: 0x00D5F111 File Offset: 0x00D5D311
		public int DisplayIndex { get; set; }

		// Token: 0x060354D3 RID: 218323 RVA: 0x00D5F11A File Offset: 0x00D5D31A
		public void Clear()
		{
		}

		// Token: 0x060354D4 RID: 218324 RVA: 0x00D5F11C File Offset: 0x00D5D31C
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060354D5 RID: 218325 RVA: 0x00D5F11E File Offset: 0x00D5D31E
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x060354D6 RID: 218326 RVA: 0x00D5F120 File Offset: 0x00D5D320
		[NullableContext(1)]
		public object GetKey(RoleDevelopSelectTargetHintItemData data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0200B069 RID: 45161
		public static class EComponentType
		{
			// Token: 0x04036BD8 RID: 224216
			public const int IconTexture = 0;

			// Token: 0x04036BD9 RID: 224217
			public const int DescText = 1;
		}
	}
}
