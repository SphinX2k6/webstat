using System;

// Token: 0x02000080 RID: 128
public enum EHttpCode
{
	// Token: 0x0400024E RID: 590
	Continue = 100,
	// Token: 0x0400024F RID: 591
	SwitchingProtocols,
	// Token: 0x04000250 RID: 592
	Processing,
	// Token: 0x04000251 RID: 593
	OK = 200,
	// Token: 0x04000252 RID: 594
	Created,
	// Token: 0x04000253 RID: 595
	Accepted,
	// Token: 0x04000254 RID: 596
	NonAuthoritativeInformation,
	// Token: 0x04000255 RID: 597
	NoContent,
	// Token: 0x04000256 RID: 598
	ResetContent,
	// Token: 0x04000257 RID: 599
	PartialContent,
	// Token: 0x04000258 RID: 600
	MultiStatus,
	// Token: 0x04000259 RID: 601
	MultipleChoices = 300,
	// Token: 0x0400025A RID: 602
	MovedPermanently,
	// Token: 0x0400025B RID: 603
	MoveTemporarily,
	// Token: 0x0400025C RID: 604
	SeeOther,
	// Token: 0x0400025D RID: 605
	NotModified,
	// Token: 0x0400025E RID: 606
	UseProxy,
	// Token: 0x0400025F RID: 607
	SwitchProxy,
	// Token: 0x04000260 RID: 608
	TemporaryRedirect,
	// Token: 0x04000261 RID: 609
	BadRequest = 400,
	// Token: 0x04000262 RID: 610
	Unauthorized,
	// Token: 0x04000263 RID: 611
	PaymentRequired,
	// Token: 0x04000264 RID: 612
	Forbidden,
	// Token: 0x04000265 RID: 613
	NotFound,
	// Token: 0x04000266 RID: 614
	MethodNotAllowed,
	// Token: 0x04000267 RID: 615
	NotAcceptable,
	// Token: 0x04000268 RID: 616
	ProxyAuthenticationRequired,
	// Token: 0x04000269 RID: 617
	RequestTimeout,
	// Token: 0x0400026A RID: 618
	Conflict,
	// Token: 0x0400026B RID: 619
	Gone,
	// Token: 0x0400026C RID: 620
	LengthRequired,
	// Token: 0x0400026D RID: 621
	PreconditionFailed,
	// Token: 0x0400026E RID: 622
	RequestEntityTooLarge,
	// Token: 0x0400026F RID: 623
	RequestURITooLong,
	// Token: 0x04000270 RID: 624
	UnsupportedMediaType,
	// Token: 0x04000271 RID: 625
	RequestedRangeNotSatisfiable,
	// Token: 0x04000272 RID: 626
	ExpectationFailed,
	// Token: 0x04000273 RID: 627
	ImATeapot,
	// Token: 0x04000274 RID: 628
	MisdirectedRequest = 421,
	// Token: 0x04000275 RID: 629
	UnprocessableEntity,
	// Token: 0x04000276 RID: 630
	Locked,
	// Token: 0x04000277 RID: 631
	FailedDependency,
	// Token: 0x04000278 RID: 632
	TooEarly,
	// Token: 0x04000279 RID: 633
	UpgradeRequired,
	// Token: 0x0400027A RID: 634
	RetryWith = 449,
	// Token: 0x0400027B RID: 635
	UnavailableForLegalReasons = 451,
	// Token: 0x0400027C RID: 636
	InternalServerError = 500,
	// Token: 0x0400027D RID: 637
	NotImplemented,
	// Token: 0x0400027E RID: 638
	BadGateway,
	// Token: 0x0400027F RID: 639
	ServiceUnavailable,
	// Token: 0x04000280 RID: 640
	GatewayTimeout,
	// Token: 0x04000281 RID: 641
	HTTPVersionNotSupported,
	// Token: 0x04000282 RID: 642
	VariantAlsoNegotiates,
	// Token: 0x04000283 RID: 643
	InsufficientStorage,
	// Token: 0x04000284 RID: 644
	BandwidthLimitExceeded = 509,
	// Token: 0x04000285 RID: 645
	NotExtended,
	// Token: 0x04000286 RID: 646
	UnparseableResponseHeaders = 600
}
