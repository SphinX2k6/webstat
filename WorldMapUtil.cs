using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002D76 RID: 11638
[NullableContext(1)]
[Nullable(0)]
public static class WorldMapUtil
{
	// Token: 0x060177C4 RID: 96196 RVA: 0x006821E0 File Offset: 0x006803E0
	public static Vector2D GetViewportSize()
	{
		if (!ObjectUtils.IsValid(Singleton<UiLayer>.Instance.UiRootItem))
		{
			return Vector2D.Create();
		}
		return Vector2D.Create((double)Singleton<UiLayer>.Instance.UiRootItem.GetWidth(), (double)Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
	}

	// Token: 0x060177C5 RID: 96197 RVA: 0x0068221E File Offset: 0x0068041E
	public static Vector2D GetViewportSizeByPool()
	{
		if (!ObjectUtils.IsValid(Singleton<UiLayer>.Instance.UiRootItem))
		{
			return Vector2D.Create();
		}
		return Vector2D.Create((double)Singleton<UiLayer>.Instance.UiRootItem.GetWidth(), (double)Singleton<UiLayer>.Instance.UiRootItem.GetHeight());
	}
}
