using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util.Layout
{
	// Token: 0x02004C7D RID: 19581
	// (Invoke) Token: 0x06033079 RID: 209017
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public delegate ILayoutItem<TLayoutRefreshItem> TLayoutRefresh<[Nullable(2)] TLayoutRefreshItem>(object data, UUIItem uiItem, int index);
}
