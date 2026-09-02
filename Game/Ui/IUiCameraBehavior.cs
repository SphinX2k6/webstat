using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x0200499C RID: 18844
	[NullableContext(1)]
	public interface IUiCameraBehavior
	{
		// Token: 0x06031374 RID: 201588
		void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend);

		// Token: 0x06031375 RID: 201589
		void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete);
	}
}
