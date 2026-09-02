using System;
using System.Runtime.CompilerServices;

// Token: 0x020020E5 RID: 8421
public class LoginDefine
{
	// Token: 0x04007B55 RID: 31573
	[Nullable(1)]
	public const string DEFAULTPORT = "5500";

	// Token: 0x0200845C RID: 33884
	public enum ELoginStatus
	{
		// Token: 0x0402CD88 RID: 183688
		Init,
		// Token: 0x0402CD89 RID: 183689
		LoginViewOpen,
		// Token: 0x0402CD8A RID: 183690
		SdkViewOpen,
		// Token: 0x0402CD8B RID: 183691
		SdkLoginSuccecc,
		// Token: 0x0402CD8C RID: 183692
		SdkLoginFail,
		// Token: 0x0402CD8D RID: 183693
		LoginHttp,
		// Token: 0x0402CD8E RID: 183694
		LoginHttpRet,
		// Token: 0x0402CD8F RID: 183695
		ConvGate,
		// Token: 0x0402CD90 RID: 183696
		ConvRet,
		// Token: 0x0402CD91 RID: 183697
		ProtoKeyReq,
		// Token: 0x0402CD92 RID: 183698
		ProtoKeyRet,
		// Token: 0x0402CD93 RID: 183699
		LoginReq,
		// Token: 0x0402CD94 RID: 183700
		LoginRet,
		// Token: 0x0402CD95 RID: 183701
		CreateReq,
		// Token: 0x0402CD96 RID: 183702
		CreateRet,
		// Token: 0x0402CD97 RID: 183703
		EnterGameReq,
		// Token: 0x0402CD98 RID: 183704
		EnterGameRet,
		// Token: 0x0402CD99 RID: 183705
		PatchVerifyFail,
		// Token: 0x0402CD9A RID: 183706
		SDKLoginBefore,
		// Token: 0x0402CD9B RID: 183707
		SDKLoginAfter
	}

	// Token: 0x0200845D RID: 33885
	public enum ELoginSex
	{
		// Token: 0x0402CD9D RID: 183709
		Girl,
		// Token: 0x0402CD9E RID: 183710
		Boy
	}

	// Token: 0x0200845E RID: 33886
	public enum ECleanFailCountWay
	{
		// Token: 0x0402CDA0 RID: 183712
		LoginSuccess,
		// Token: 0x0402CDA1 RID: 183713
		RefreshTime,
		// Token: 0x0402CDA2 RID: 183714
		TestLogin
	}

	// Token: 0x0200845F RID: 33887
	public enum ESdkLoginCode
	{
		// Token: 0x0402CDA4 RID: 183716
		LoginFailed,
		// Token: 0x0402CDA5 RID: 183717
		LoginSuccess,
		// Token: 0x0402CDA6 RID: 183718
		FirstLogin
	}

	// Token: 0x02008460 RID: 33888
	public enum ESdkLoginState
	{
		// Token: 0x0402CDA8 RID: 183720
		Logout,
		// Token: 0x0402CDA9 RID: 183721
		Login,
		// Token: 0x0402CDAA RID: 183722
		LoggingIn
	}
}
