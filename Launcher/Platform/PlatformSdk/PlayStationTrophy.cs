using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045C8 RID: 17864
	public class PlayStationTrophy
	{
		// Token: 0x0602ED03 RID: 191747 RVA: 0x00B15D40 File Offset: 0x00B13F40
		[NullableContext(1)]
		public UniTask Init(UniversalDataSystemManager uds, PlatformSdkNew sdkSource)
		{
			PlayStationTrophy.<Init>d__11 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.uds = uds;
			<Init>d__.sdkSource = sdkSource;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<PlayStationTrophy.<Init>d__11>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED04 RID: 191748 RVA: 0x00B15D94 File Offset: 0x00B13F94
		private UniTask InitTrophy()
		{
			PlayStationTrophy.<InitTrophy>d__12 <InitTrophy>d__;
			<InitTrophy>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTrophy>d__.<>4__this = this;
			<InitTrophy>d__.<>1__state = -1;
			<InitTrophy>d__.<>t__builder.Start<PlayStationTrophy.<InitTrophy>d__12>(ref <InitTrophy>d__);
			return <InitTrophy>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED05 RID: 191749 RVA: 0x00B15DD8 File Offset: 0x00B13FD8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public UniTask<List<ISdkTrophyInfo>> GetSdkTrophyInfo(int offset = 0, int length = 0)
		{
			PlayStationTrophy.<GetSdkTrophyInfo>d__13 <GetSdkTrophyInfo>d__;
			<GetSdkTrophyInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<ISdkTrophyInfo>>.Create();
			<GetSdkTrophyInfo>d__.<>4__this = this;
			<GetSdkTrophyInfo>d__.offset = offset;
			<GetSdkTrophyInfo>d__.length = length;
			<GetSdkTrophyInfo>d__.<>1__state = -1;
			<GetSdkTrophyInfo>d__.<>t__builder.Start<PlayStationTrophy.<GetSdkTrophyInfo>d__13>(ref <GetSdkTrophyInfo>d__);
			return <GetSdkTrophyInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED06 RID: 191750 RVA: 0x00B15E2C File Offset: 0x00B1402C
		public UniTask<bool> UnlockSdkTrophy(int trophyId)
		{
			PlayStationTrophy.<UnlockSdkTrophy>d__14 <UnlockSdkTrophy>d__;
			<UnlockSdkTrophy>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UnlockSdkTrophy>d__.<>4__this = this;
			<UnlockSdkTrophy>d__.trophyId = trophyId;
			<UnlockSdkTrophy>d__.<>1__state = -1;
			<UnlockSdkTrophy>d__.<>t__builder.Start<PlayStationTrophy.<UnlockSdkTrophy>d__14>(ref <UnlockSdkTrophy>d__);
			return <UnlockSdkTrophy>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED07 RID: 191751 RVA: 0x00B15E78 File Offset: 0x00B14078
		private void ProcessUnlockQueue()
		{
			PlayStationTrophy.<>c__DisplayClass15_0 CS$<>8__locals1 = new PlayStationTrophy.<>c__DisplayClass15_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.UnlockQueue.Count == 0)
			{
				this.IsUnlocking = false;
				return;
			}
			this.IsUnlocking = true;
			CS$<>8__locals1.data = this.UnlockQueue[0];
			this.UnlockQueue.RemoveAt(0);
			int context = this.UniversalDataSystemManager.GetContext();
			int handle = this.UniversalDataSystemManager.GetHandle();
			int item = CS$<>8__locals1.data.Item1;
			FPlayStationUnlockTrophyCallBack fplayStationUnlockTrophyCallBack = global::DelegateUtils.ToManualReleaseDelegate<FPlayStationUnlockTrophyCallBack>(new Action<int>(CS$<>8__locals1.<ProcessUnlockQueue>g__OnUnlockTrophy|0));
			UKuroStaticPS5Library.UnlockTrophyWithContextIdAndHandleIdAsync(context, handle, item, fplayStationUnlockTrophyCallBack);
		}

		// Token: 0x0602ED08 RID: 191752 RVA: 0x00B15F08 File Offset: 0x00B14108
		public UniTask<bool> UpdateSdkTrophyProgress(int trophyId, int progress)
		{
			PlayStationTrophy.<UpdateSdkTrophyProgress>d__16 <UpdateSdkTrophyProgress>d__;
			<UpdateSdkTrophyProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateSdkTrophyProgress>d__.<>4__this = this;
			<UpdateSdkTrophyProgress>d__.trophyId = trophyId;
			<UpdateSdkTrophyProgress>d__.progress = progress;
			<UpdateSdkTrophyProgress>d__.<>1__state = -1;
			<UpdateSdkTrophyProgress>d__.<>t__builder.Start<PlayStationTrophy.<UpdateSdkTrophyProgress>d__16>(ref <UpdateSdkTrophyProgress>d__);
			return <UpdateSdkTrophyProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED09 RID: 191753 RVA: 0x00B15F5C File Offset: 0x00B1415C
		private UniTask<int> RegistTrophyContextAsync(int contextId, int handleId)
		{
			PlayStationTrophy.<RegistTrophyContextAsync>d__17 <RegistTrophyContextAsync>d__;
			<RegistTrophyContextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<RegistTrophyContextAsync>d__.contextId = contextId;
			<RegistTrophyContextAsync>d__.handleId = handleId;
			<RegistTrophyContextAsync>d__.<>1__state = -1;
			<RegistTrophyContextAsync>d__.<>t__builder.Start<PlayStationTrophy.<RegistTrophyContextAsync>d__17>(ref <RegistTrophyContextAsync>d__);
			return <RegistTrophyContextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED0A RID: 191754 RVA: 0x00B15FA8 File Offset: 0x00B141A8
		private UniTask<int> CreateTrophyContextAsync()
		{
			PlayStationTrophy.<CreateTrophyContextAsync>d__18 <CreateTrophyContextAsync>d__;
			<CreateTrophyContextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<CreateTrophyContextAsync>d__.<>4__this = this;
			<CreateTrophyContextAsync>d__.<>1__state = -1;
			<CreateTrophyContextAsync>d__.<>t__builder.Start<PlayStationTrophy.<CreateTrophyContextAsync>d__18>(ref <CreateTrophyContextAsync>d__);
			return <CreateTrophyContextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED0B RID: 191755 RVA: 0x00B15FEC File Offset: 0x00B141EC
		private UniTask<int> CreateTrophyHandleAsync()
		{
			PlayStationTrophy.<CreateTrophyHandleAsync>d__19 <CreateTrophyHandleAsync>d__;
			<CreateTrophyHandleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<CreateTrophyHandleAsync>d__.<>1__state = -1;
			<CreateTrophyHandleAsync>d__.<>t__builder.Start<PlayStationTrophy.<CreateTrophyHandleAsync>d__19>(ref <CreateTrophyHandleAsync>d__);
			return <CreateTrophyHandleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED0C RID: 191756 RVA: 0x00B16028 File Offset: 0x00B14228
		private UniTask<bool> DestroyTrophyHandleAsync(int handleId)
		{
			PlayStationTrophy.<DestroyTrophyHandleAsync>d__20 <DestroyTrophyHandleAsync>d__;
			<DestroyTrophyHandleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DestroyTrophyHandleAsync>d__.handleId = handleId;
			<DestroyTrophyHandleAsync>d__.<>1__state = -1;
			<DestroyTrophyHandleAsync>d__.<>t__builder.Start<PlayStationTrophy.<DestroyTrophyHandleAsync>d__20>(ref <DestroyTrophyHandleAsync>d__);
			return <DestroyTrophyHandleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED0D RID: 191757 RVA: 0x00B1606C File Offset: 0x00B1426C
		private UniTask<bool> DestroyTrophyContextAsync(int contextId)
		{
			PlayStationTrophy.<DestroyTrophyContextAsync>d__21 <DestroyTrophyContextAsync>d__;
			<DestroyTrophyContextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DestroyTrophyContextAsync>d__.contextId = contextId;
			<DestroyTrophyContextAsync>d__.<>1__state = -1;
			<DestroyTrophyContextAsync>d__.<>t__builder.Start<PlayStationTrophy.<DestroyTrophyContextAsync>d__21>(ref <DestroyTrophyContextAsync>d__);
			return <DestroyTrophyContextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED0E RID: 191758 RVA: 0x00B160AF File Offset: 0x00B142AF
		public void Clear()
		{
			this.DestroyTrophyHandleAsync(this.TrophyHandleId).Forget<bool>();
			this.DestroyTrophyContextAsync(this.TrophyContextId).Forget<bool>();
		}

		// Token: 0x0401AA0A RID: 109066
		private const int DEFAULTLABEL = 0;

		// Token: 0x0401AA0B RID: 109067
		private const int PROGRESSTYPEPROGRESS = 1;

		// Token: 0x0401AA0C RID: 109068
		private const int PROGRESSTYPEUNLOCK = 0;

		// Token: 0x0401AA0D RID: 109069
		[Nullable(2)]
		private UniversalDataSystemManager UniversalDataSystemManager;

		// Token: 0x0401AA0E RID: 109070
		[Nullable(2)]
		private PlatformSdkNew PlatformSource;

		// Token: 0x0401AA0F RID: 109071
		private int TrophyContextId;

		// Token: 0x0401AA10 RID: 109072
		private int TrophyHandleId;

		// Token: 0x0401AA11 RID: 109073
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ISdkTrophyInfo> CurrentTrophyInfo;

		// Token: 0x0401AA12 RID: 109074
		[Nullable(1)]
		private readonly Dictionary<int, ISdkTrophyInfo> CurrentTrophyMap = new Dictionary<int, ISdkTrophyInfo>();

		// Token: 0x0401AA13 RID: 109075
		[TupleElementNames(new string[]
		{
			"TrophyId",
			"Task"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private readonly List<ValueTuple<int, Action<bool>>> UnlockQueue = new List<ValueTuple<int, Action<bool>>>();

		// Token: 0x0401AA14 RID: 109076
		private bool IsUnlocking;
	}
}
