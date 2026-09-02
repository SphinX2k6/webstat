using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A21 RID: 18977
	[NullableContext(1)]
	public interface IOpenAndCloseViewHotKey
	{
		// Token: 0x17008452 RID: 33874
		// (get) Token: 0x06031943 RID: 203075
		// (set) Token: 0x06031944 RID: 203076
		int ConfigId { get; set; }

		// Token: 0x17008453 RID: 33875
		// (get) Token: 0x06031945 RID: 203077
		// (set) Token: 0x06031946 RID: 203078
		string ActionName { get; set; }

		// Token: 0x17008454 RID: 33876
		// (get) Token: 0x06031947 RID: 203079
		// (set) Token: 0x06031948 RID: 203080
		EOpenAndCloseViewInputControllerType InputControllerType { get; set; }

		// Token: 0x17008455 RID: 33877
		// (get) Token: 0x06031949 RID: 203081
		// (set) Token: 0x0603194A RID: 203082
		EUiViewName ViewName { get; set; }

		// Token: 0x17008456 RID: 33878
		// (get) Token: 0x0603194B RID: 203083
		// (set) Token: 0x0603194C RID: 203084
		string[] ViewParam { get; set; }

		// Token: 0x17008457 RID: 33879
		// (get) Token: 0x0603194D RID: 203085
		// (set) Token: 0x0603194E RID: 203086
		bool IsPressTrigger { get; set; }

		// Token: 0x17008458 RID: 33880
		// (get) Token: 0x0603194F RID: 203087
		// (set) Token: 0x06031950 RID: 203088
		int PressStartTime { get; set; }

		// Token: 0x17008459 RID: 33881
		// (get) Token: 0x06031951 RID: 203089
		// (set) Token: 0x06031952 RID: 203090
		int PressTriggerTime { get; set; }

		// Token: 0x1700845A RID: 33882
		// (get) Token: 0x06031953 RID: 203091
		// (set) Token: 0x06031954 RID: 203092
		bool IsReleaseTrigger { get; set; }

		// Token: 0x1700845B RID: 33883
		// (get) Token: 0x06031955 RID: 203093
		// (set) Token: 0x06031956 RID: 203094
		int ReleaseInvalidTime { get; set; }

		// Token: 0x1700845C RID: 33884
		// (get) Token: 0x06031957 RID: 203095
		// (set) Token: 0x06031958 RID: 203096
		bool IsPressClose { get; set; }

		// Token: 0x1700845D RID: 33885
		// (get) Token: 0x06031959 RID: 203097
		// (set) Token: 0x0603195A RID: 203098
		bool IsReleaseClose { get; set; }

		// Token: 0x1700845E RID: 33886
		// (get) Token: 0x0603195B RID: 203099
		// (set) Token: 0x0603195C RID: 203100
		Func<bool> IsAllowOpenViewByShortcutKey { get; set; }

		// Token: 0x1700845F RID: 33887
		// (get) Token: 0x0603195D RID: 203101
		// (set) Token: 0x0603195E RID: 203102
		Func<bool> IsAllowCloseViewByShortcutKey { get; set; }

		// Token: 0x17008460 RID: 33888
		// (get) Token: 0x0603195F RID: 203103
		// (set) Token: 0x06031960 RID: 203104
		Func<string, InputDistributeDefine.EActionType, bool> IsLockShortcutKey { get; set; }

		// Token: 0x17008461 RID: 33889
		// (get) Token: 0x06031961 RID: 203105
		// (set) Token: 0x06031962 RID: 203106
		[Nullable(2)]
		Action OpenViewCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008462 RID: 33890
		// (get) Token: 0x06031963 RID: 203107
		// (set) Token: 0x06031964 RID: 203108
		[Nullable(2)]
		Action CloseViewCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
