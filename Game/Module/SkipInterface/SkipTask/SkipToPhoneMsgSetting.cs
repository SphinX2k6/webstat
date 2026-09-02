using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F53 RID: 20307
	public class SkipToPhoneMsgSetting : SkipTask
	{
		// Token: 0x06034609 RID: 214537 RVA: 0x00D1BE10 File Offset: 0x00D1A010
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			base.Finish();
			int itemId = Convert.ToInt32(data[0]);
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhoneMsg))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MessageSystemUnlockTip", Array.Empty<object>());
				return;
			}
			this.OpenPhoneMsgSettingAsync(itemId).Forget();
		}

		// Token: 0x0603460A RID: 214538 RVA: 0x00D1BE60 File Offset: 0x00D1A060
		private UniTask OpenPhoneMsgSettingAsync(int itemId)
		{
			SkipToPhoneMsgSetting.<OpenPhoneMsgSettingAsync>d__1 <OpenPhoneMsgSettingAsync>d__;
			<OpenPhoneMsgSettingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenPhoneMsgSettingAsync>d__.itemId = itemId;
			<OpenPhoneMsgSettingAsync>d__.<>1__state = -1;
			<OpenPhoneMsgSettingAsync>d__.<>t__builder.Start<SkipToPhoneMsgSetting.<OpenPhoneMsgSettingAsync>d__1>(ref <OpenPhoneMsgSettingAsync>d__);
			return <OpenPhoneMsgSettingAsync>d__.<>t__builder.Task;
		}
	}
}
