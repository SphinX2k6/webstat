using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace UnrealEngine.Extension
{
	// Token: 0x02004449 RID: 17481
	public static class LGuiExtension
	{
		// Token: 0x0602E39E RID: 189342 RVA: 0x00ADC140 File Offset: 0x00ADA340
		public static FVector2D GetUiViewportSize()
		{
			if (!ObjectUtils.IsValid(Singleton<UiLayer>.Instance.UiRootItem))
			{
				return new FVector2D();
			}
			float width = Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
			return new FVector2D(width, height);
		}

		// Token: 0x0602E39F RID: 189343 RVA: 0x00ADC18C File Offset: 0x00ADA38C
		[NullableContext(1)]
		public static Vector2D GetViewportSize()
		{
			if (!ObjectUtils.IsValid(Singleton<UiLayer>.Instance.UiRootItem))
			{
				return new Vector2D();
			}
			double width = (double)Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
			return new Vector2D(width, (double)height);
		}
	}
}
