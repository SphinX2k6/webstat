using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200578B RID: 22411
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuDetailPopViewItemPanel : UiPanelBase
	{
		// Token: 0x06039037 RID: 233527 RVA: 0x00E72A0F File Offset: 0x00E70C0F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06039038 RID: 233528 RVA: 0x00E72A48 File Offset: 0x00E70C48
		protected override UniTask OnBeforeStartAsync()
		{
			this.View = new MenuDetailPopViewItemView(base.GetText(1), base.GetTexture(0), delegate(string path, UUITexture texture)
			{
				base.SetTextureByPath(path, texture, null, null);
			});
			return UniTask.CompletedTask;
		}

		// Token: 0x06039039 RID: 233529 RVA: 0x00E72A74 File Offset: 0x00E70C74
		public void RefreshByData(MenuDetailPopItemData data)
		{
			MenuDetailPopViewItemView view = this.View;
			if (view == null)
			{
				return;
			}
			view.RefreshByData(data);
		}

		// Token: 0x0603903A RID: 233530 RVA: 0x00E72A87 File Offset: 0x00E70C87
		protected override void OnBeforeDestroy()
		{
			MenuDetailPopViewItemView view = this.View;
			if (view != null)
			{
				view.Clear();
			}
			this.View = null;
		}

		// Token: 0x0402076F RID: 132975
		private const string VIDEO_NAME = "MenuDetailPopViewItemPanel";

		// Token: 0x04020770 RID: 132976
		[Nullable(2)]
		private MenuDetailPopViewItemView View;
	}
}
