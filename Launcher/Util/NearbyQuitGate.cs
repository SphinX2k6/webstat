using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044AC RID: 17580
	public class NearbyQuitGate : IStaticVariableResetter
	{
		// Token: 0x0602E579 RID: 189817 RVA: 0x00AE23DD File Offset: 0x00AE05DD
		static NearbyQuitGate()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(NearbyQuitGate.CreateStaticDefaultValue), new Action(NearbyQuitGate.ResetStaticDefaultValue));
		}

		// Token: 0x0602E57A RID: 189818 RVA: 0x00AE23FC File Offset: 0x00AE05FC
		public static void Trip()
		{
			if (NearbyQuitGate.bPending)
			{
				return;
			}
			NearbyQuitGate.bPending = true;
			Singleton<LauncherLog>.Instance.Info("[NearbyQuitGate] tripped.", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E57B RID: 189819 RVA: 0x00AE242F File Offset: 0x00AE062F
		public static bool IsPending()
		{
			return NearbyQuitGate.bPending;
		}

		// Token: 0x0602E57C RID: 189820 RVA: 0x00AE2436 File Offset: 0x00AE0636
		[NullableContext(1)]
		public static void SetPresenter(Func<UniTask> presenter)
		{
			NearbyQuitGate.Presenter = presenter;
		}

		// Token: 0x0602E57D RID: 189821 RVA: 0x00AE2440 File Offset: 0x00AE0640
		public static UniTask ParkIfPending()
		{
			NearbyQuitGate.<ParkIfPending>d__7 <ParkIfPending>d__;
			<ParkIfPending>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ParkIfPending>d__.<>1__state = -1;
			<ParkIfPending>d__.<>t__builder.Start<NearbyQuitGate.<ParkIfPending>d__7>(ref <ParkIfPending>d__);
			return <ParkIfPending>d__.<>t__builder.Task;
		}

		// Token: 0x0602E57E RID: 189822 RVA: 0x00AE247B File Offset: 0x00AE067B
		public static void CreateStaticDefaultValue()
		{
			NearbyQuitGate.bPending = false;
			NearbyQuitGate.bPresented = false;
			NearbyQuitGate.Presenter = null;
		}

		// Token: 0x0602E57F RID: 189823 RVA: 0x00AE248F File Offset: 0x00AE068F
		public static void ResetStaticDefaultValue()
		{
			NearbyQuitGate.bPending = false;
			NearbyQuitGate.bPresented = false;
			NearbyQuitGate.Presenter = null;
		}

		// Token: 0x0401A573 RID: 107891
		private static bool bPending;

		// Token: 0x0401A574 RID: 107892
		private static bool bPresented;

		// Token: 0x0401A575 RID: 107893
		[Nullable(2)]
		private static Func<UniTask> Presenter;
	}
}
