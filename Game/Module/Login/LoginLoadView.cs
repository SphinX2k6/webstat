using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A06 RID: 23046
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginLoadView : UiPanelBase
	{
		// Token: 0x0603A5ED RID: 239085 RVA: 0x00ECCE46 File Offset: 0x00ECB046
		public LoginLoadView(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0603A5EE RID: 239086 RVA: 0x00ECCE58 File Offset: 0x00ECB058
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A5EF RID: 239087 RVA: 0x00ECCEE2 File Offset: 0x00ECB0E2
		protected override void OnStart()
		{
			this.ProgressText = base.GetText(1);
			this.DownLoadTipsText = base.GetText(2);
		}

		// Token: 0x0603A5F0 RID: 239088 RVA: 0x00ECCEFE File Offset: 0x00ECB0FE
		public void SetDownLoadTipsTextActive(bool value)
		{
			UUIText downLoadTipsText = this.DownLoadTipsText;
			if (downLoadTipsText == null)
			{
				return;
			}
			downLoadTipsText.SetUIActive(value);
		}

		// Token: 0x0603A5F1 RID: 239089 RVA: 0x00ECCF11 File Offset: 0x00ECB111
		public void SetDownLoadTipsText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(this.DownLoadTipsText, textId, Array.Empty<object>());
		}

		// Token: 0x0603A5F2 RID: 239090 RVA: 0x00ECCF29 File Offset: 0x00ECB129
		public void SetProgressSprite(float value)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(value);
		}

		// Token: 0x0603A5F3 RID: 239091 RVA: 0x00ECCF3D File Offset: 0x00ECB13D
		public void SetProgressText(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(this.ProgressText, textId, args);
		}

		// Token: 0x040210E2 RID: 135394
		private UUIText ProgressText;

		// Token: 0x040210E3 RID: 135395
		private UUIText DownLoadTipsText;
	}
}
