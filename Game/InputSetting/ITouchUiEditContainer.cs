using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007015 RID: 28693
	[NullableContext(1)]
	public interface ITouchUiEditContainer
	{
		// Token: 0x06045781 RID: 284545
		UniTask LoadPanel(UUIItem parent, string[] resIdList, CommonTouchUiEditGroup groupConfig);

		// Token: 0x06045782 RID: 284546
		[return: Nullable(2)]
		UUIItem GetItem(string resId, int index, int subPanelIndex);

		// Token: 0x06045783 RID: 284547
		UUIItem[] GetRegistryItemList(string resId);

		// Token: 0x06045784 RID: 284548
		UUIItem GetRootItem();

		// Token: 0x06045785 RID: 284549
		void OnViewDestroy();
	}
}
