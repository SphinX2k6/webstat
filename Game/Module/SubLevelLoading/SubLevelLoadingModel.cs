using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SubLevelLoading
{
	// Token: 0x02004EF5 RID: 20213
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SubLevelLoadingModel : ModelBase<SubLevelLoadingModel>
	{
		// Token: 0x17008A04 RID: 35332
		// (get) Token: 0x060343CB RID: 213963 RVA: 0x00D10B9D File Offset: 0x00D0ED9D
		// (set) Token: 0x060343CC RID: 213964 RVA: 0x00D10BA5 File Offset: 0x00D0EDA5
		public EScreenEffectType ScreenEffect
		{
			get
			{
				return this.ScreenEffectInternal;
			}
			set
			{
				this.ScreenEffectInternal = value;
			}
		}

		// Token: 0x17008A05 RID: 35333
		// (get) Token: 0x060343CE RID: 213966 RVA: 0x00D10BB7 File Offset: 0x00D0EDB7
		// (set) Token: 0x060343CD RID: 213965 RVA: 0x00D10BAE File Offset: 0x00D0EDAE
		public GameModePromise LoadSubLevelPromise
		{
			get
			{
				return this.LoadSubLevelPromiseInternal;
			}
			set
			{
				this.LoadSubLevelPromiseInternal = value;
			}
		}

		// Token: 0x060343CF RID: 213967 RVA: 0x00D10BBF File Offset: 0x00D0EDBF
		protected override bool OnLeaveLevel()
		{
			return true;
		}

		// Token: 0x060343D0 RID: 213968 RVA: 0x00D10BC2 File Offset: 0x00D0EDC2
		protected override bool OnClear()
		{
			this.ScreenEffectInternal = EScreenEffectType.ScreenEffectNone;
			ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
			this.LoadSubLevelPromiseInternal = null;
			return true;
		}

		// Token: 0x0401E24A RID: 123466
		private EScreenEffectType ScreenEffectInternal;

		// Token: 0x0401E24B RID: 123467
		private GameModePromise LoadSubLevelPromiseInternal;
	}
}
