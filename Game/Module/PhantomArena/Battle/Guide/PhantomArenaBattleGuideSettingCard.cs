using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005617 RID: 22039
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideSettingCard : PhantomArenaBattleGuideDataBase<IBvbDeploy>
	{
		// Token: 0x060382B6 RID: 230070 RVA: 0x00E39574 File Offset: 0x00E37774
		public PhantomArenaBattleGuideSettingCard(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x060382B7 RID: 230071 RVA: 0x00E39580 File Offset: 0x00E37780
		public unsafe override bool CheckCanExecute(params object[] params_)
		{
			if (params_.Length < 2)
			{
				return false;
			}
			int num = (int)params_[0];
			int num2 = (int)params_[1];
			if (num == -1 || num2 == -1)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "PhantomArenaBattleGuideSettingCard invalid value";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handIndex", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("battleIndex", num2);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return (this.Data.HandCardIndex == null || this.Data.HandCardIndex.Value - 1 == num) && (this.Data.BoardPosIndexList == null || this.Data.BoardPosIndexList.Contains(num2 + 1));
		}
	}
}
